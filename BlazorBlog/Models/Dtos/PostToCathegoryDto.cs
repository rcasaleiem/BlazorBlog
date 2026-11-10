using BlazorBlog.Models.Tables;

namespace BlazorBlog.Models.Dtos
{
    public class PostToCathegoryDto
    {
        public CathegoriesTable cathegory { get; set; } //\\navigation
        public PostsTable post { get; set; }  //\\navigation
    }
}
