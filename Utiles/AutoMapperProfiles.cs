using AutoMapper;
using api_web.DTOs;
using api_web.Models;


namespace api_web.Utiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Consultoriomedico, ConsultoriomedicoDTO>();
        }
    }
}
