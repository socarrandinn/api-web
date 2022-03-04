
using api_web.Context;
using api_web.DTOs.Users;
using api_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace api_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly ConsultorioContext _context;

        public AuthController(IConfiguration configuration, ConsultorioContext context)
        {
            _configuration = configuration;
            _context = context;

        }

        

        public IConfiguration Configuration { get; }

        [HttpPost("registrar")]
        public async Task<ActionResult<User>> Registrar(UserRegisterDTO req)
        {

            CreatePasswordHast(req.Password, out byte[] passwordHast, out byte[] passwordSalt);
            
            user.Usuario = req.Usuario;
            user.Password = passwordHast;
            user.Passwordsalt = passwordSalt;   

            return Ok(user);    
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserRegisterDTO req)
        {
            if (user.Usuario != req.Usuario)
            {
                return BadRequest("Ususario no encontrado");
            }

            if(!VerificarPasswordHast(req.Password, user.Password, user.Passwordsalt))
            {
                return BadRequest("Contraseña incorrecta..");
            }


            string token = CrearToken(user);

            return Ok(token);
        }


        private void CreatePasswordHast(string password, out byte[] passwordHast, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHast = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerificarPasswordHast(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computarHast = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computarHast.SequenceEqual(passwordHash);
            }
        }

        private string CrearToken(User user)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Usuario)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value ));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }



    }
}
