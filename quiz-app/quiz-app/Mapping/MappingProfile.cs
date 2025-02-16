using AutoMapper;
using quiz_app.DTO;
using quiz_app.Entities;

namespace quiz_app.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<User, AuthResponseDTO>();
        }
    }
}
