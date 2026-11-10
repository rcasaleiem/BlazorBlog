using AutoMapper;
using BlazorBlog.Models.Dtos;
using BlazorBlog.Models.Tables;

namespace BlazorBlog.Models.Mappers
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<PostsTable, PostDto>()
                .ForMember(dest => dest.content, opt => opt.MapFrom(src => src.content != null ? src.content : null))
                .ForMember(dest => dest.postToTags, opt => opt.MapFrom(src => src.postToTags != null ? src.postToTags : null))
                .ForMember(dest => dest.comments, opt => opt.MapFrom(src => src.comments != null ? src.comments : null))
                .ForMember(dest => dest.creationDate, opt => opt.MapFrom(src => src.creationDate != null ? src.creationDate : null))
                .ForMember(dest => dest.postToTags, opt => opt.MapFrom(src => src.postToTags != null ? src.postToTags : null))
                .ForMember(dest => dest.postToCathegory, opt => opt.MapFrom(src => src.PostToCathegory != null ? src.PostToCathegory : null));

            CreateMap<CommentsTable, CommentDto>()
                .ForMember(dest => dest.commentId, opt => opt.MapFrom(src => src.id != null ? src.content : null))
                .ForMember(dest => dest.content, opt => opt.MapFrom(src => src.content != null ? src.content : null))
                .ForMember(dest => dest.author, opt => opt.MapFrom(src => src.author != null ? src.author : null))
                .ForMember(dest => dest.RespondedComment, opt => opt.MapFrom(src => src.responseToComment != null ? src.responseToComment : null))
                .ForMember(dest => dest.responsesToComment, opt => opt.MapFrom(src => src.responsesToComment != null ? src.responsesToComment : null));

            CreateMap<UsersTable, UserDto>()
                .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.username != null ? src.username : null))
                .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password != null ? src.password : null))
                .ForMember(dest => dest.comments, opt => opt.MapFrom(src => src.comments != null ? src.comments : null));

            CreateMap<TagsTable, TagDto>()
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag != null ? src.Tag : null));

            CreateMap<CathegoriesTable, CathegoryDto>()
                .ForMember(dest => dest.cathegory, opt => opt.MapFrom(src => src.cathegory != null ? src.cathegory :  null));

        }
        
            
    }
}
