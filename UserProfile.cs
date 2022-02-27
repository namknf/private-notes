namespace PrivateNotes
{
    using AutoMapper;
    using PrivateNotes.Models;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, Account>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dst => dst.RegisterDate, opt => opt.MapFrom(src => src.RegisterDate))
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                ;

            CreateMap<User, AuthorizeResponse>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dst => dst.RegisterDate, opt => opt.MapFrom(src => src.RegisterDate))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dst => dst.Token, opt => opt.MapFrom(src => src.Token))
                ;
        }
    }
}
