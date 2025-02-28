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
            CreateMap<User, UserWithRoleDTO>();

            CreateMap<QuizRecord, QuizRecordDTO>();
            CreateMap<QuizRecord, QuizRecordResponseDTO>();
            CreateMap<QuizRecordResponseDTO, QuizRecord>();
            CreateMap<QuizRecord, UserQuizRecordsDTO>();


            CreateMap<Quiz, QuizDTO>();
            CreateMap<Quiz, QuizResponseDTO>();
            CreateMap<QuizResponseDTO, Quiz>();


        }
    }
}
