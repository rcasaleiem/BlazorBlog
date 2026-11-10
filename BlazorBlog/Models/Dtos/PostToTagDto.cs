using BlazorBlog.Models.Tables;

namespace BlazorBlog.Models.Dtos
{
    public class PostToTagDto
    {
        public PostsTable? post { get; set; }  //\\navigation
        public TagsTable? tag { get; set; }    //\\navigation
    }
}
