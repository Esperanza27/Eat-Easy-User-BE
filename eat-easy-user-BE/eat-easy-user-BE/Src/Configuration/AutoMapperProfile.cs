using AutoMapper;
using eat_easy_user_BE.Src.DTOS;
using eat_easy_user_BE.Src.Models;

namespace eat_easy_user_BE.Src.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mappa UserModel a UserDTO
            CreateMap<UserModel, UserDTO>();
            // Mappa UserCreateDTO a UserModel (per la creazione di un nuovo utente)
            CreateMap<UserCreateDTO, UserModel>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // La password sarà hashata prima di essere salvata

            // Mappa UserUpdateDTO  a UserModel
            //CreateMap<UserUpdateDTO, UserModel>()
            //.ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
