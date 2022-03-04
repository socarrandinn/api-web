using api_web.Context;
using api_web.DTOs.Users;
using api_web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace api_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTTokenController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly ConsultorioContext _context;

        public static User user = new User();

        public JWTTokenController(IConfiguration configuration, ConsultorioContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<User>> Registrar(UserRegisterDTO req)
        {          

            //Encriptar contraseña
            CreatePasswordHast(req.Password, out byte[] passwordHast, out byte[] passwordSalt);

            var existeUser = await GetUsuarioByUsuario(req.Usuario);

            if (existeUser != null)
            {
                return BadRequest("Ya existe este Usuario");

            }else
            {
                user.Usuario = req.Usuario;
                user.Passwordsalt = passwordSalt;
                user.Password = passwordHast;
                user.Email = req.Email;
                user.Consultoriomedicoid = req.Consultoriomedicoid;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }

            

           

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO req)
        {
            if(req != null && req.Usuario != null && req.Password != null)            {

                var userData = await GetUsuarioByUsuario(req.Usuario);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                
                //verificar si existe usuario
                if(userData != null)
                {
                    //verificar si es corecta la contraseña
                    if (!VerificarPasswordHast(req.Password, userData.Password, userData.Passwordsalt))
                    {
                        return BadRequest("Contraseña incorrecta..");
                    }
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),                      
                        new Claim("Usuario", req.Usuario),
                        new Claim("Password", req.Password)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            jwt.Issuer,
                            jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn);

                    return Ok (new JwtSecurityTokenHandler().WriteToken(token));
                }
                return BadRequest("No existe el usuario");
            }
            else
            {
                return BadRequest("Credenciales Invalidos");
            }
        }




        //FUNCIONES 

        [HttpGet]
        public async Task<User> GetUsuarioByUsuario(string usuario)
        {
            return await _context.Users.FirstOrDefaultAsync(
                u => u.Usuario == usuario);
        }


        private void CreatePasswordHast(string password, out byte[] passwordHast, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHast = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
             
        }

        private bool VerificarPasswordHast(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computarHast = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computarHast.SequenceEqual(passwordHash);
            }
        }

        
    }
}
