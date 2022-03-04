namespace PrivateNotes
{
    using AutoMapper;
    using PrivateNotes.Models;

    public class NoteMapper : Profile
    {
        public NoteMapper()
        {
            CreateMap<Note, NoteResponse>()
                .ForMember(dst => dst.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dst => dst.NoteDate, opt => opt.MapFrom(src => src.NoteDate))
                .ForMember(dst => dst.NoteUserId, opt => opt.MapFrom(src => src.NoteUserId))
                .ForMember(dst => dst.NoteUser, opt => opt.MapFrom(src => src.NoteUser))
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                ;

            CreateMap<NoteResponse, Note>()
                .ForMember(dst => dst.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dst => dst.NoteDate, opt => opt.MapFrom(src => src.NoteDate))
                .ForMember(dst => dst.NoteUserId, opt => opt.MapFrom(src => src.NoteUserId))
                .ForMember(dst => dst.NoteUser, opt => opt.MapFrom(src => src.NoteUser))
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                ;
        }
    }
}
