using BlazorBlog.Models.Tables;
using MediatR;

namespace BlazorBlog.Features.Posts
{
        public class GetPostQuery : IRequest<PostsTable?>    // ← output declared here
        {
            public int Id { get; set; }                       // ← input
        }
}
