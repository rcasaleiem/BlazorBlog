using BlazorBlog.Models.Tables;
using BlazorBlog.Services;
using MediatR;

namespace BlazorBlog.Features.Posts
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostsTable?>
    {
        private readonly CrudHandler crudHandler;

        public GetPostQueryHandler(CrudHandler crudHandler)   
        {
            this.crudHandler = crudHandler;
        }

        public async Task<PostsTable?> Handle(GetPostQuery request, CancellationToken ct)
        {
            return await crudHandler.Get<PostsTable, PostsTable>(request.Id);
        }
    }
}
