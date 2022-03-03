namespace PrivateNotes
{
    using AutoMapper;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, RegistrationModel>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                ;

            CreateMap<RegistrationModel, User>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                ;

            CreateMap<User, AuthorizeResponse>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dst => dst.Token, opt => opt.MapFrom(src => src.Token))
                ;
        }
    }
}
