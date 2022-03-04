/*using api_web.DTOs;
using api_web.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace api_web.Utiles
{
    public class Seed
    {


        private void Seed(ModelBuilder builder)
        {
            CreatePasswordHast("admin", out byte[] passwordHast, out byte[] passwordSalt);

            var consultorio = new ConsultoriomedicoDTO()
            {

                Id = 1,
                Nombre = "consultorio"
            };

            builder.Entity<Consultoriomedico>().HasData(consultorio);

            var usuarioAdmin = new User()
            {
                Id = 1,
                Email = "admin@gmail.com",
                Usuario = "admin",
                Password = passwordHast,
                Passwordsalt = passwordSalt,
                Consultoriomedicoid = consultorio.Id
            };

            var rolAdmin = new Rol()
            {
                Id = 1,
                Name = "Administrador",
                Role = "ROLE_ADMIN"
            };

            builder.Entity<Rol>().HasData(rolAdmin);
            builder.Entity<User>().HasData(usuarioAdmin);

            var userRoleAdmin = new Userrol()
            {
                Rolid = rolAdmin.Id,
                Userid = usuarioAdmin.Id
            };

            builder.Entity<Userrol>().HasData(userRoleAdmin);
        }


        private void CreatePasswordHast(string password, out byte[] passwordHast, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHast = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}*/
