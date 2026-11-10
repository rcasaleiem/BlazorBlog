using BlazorBlog.Models.Tables;

namespace BlazorBlog.Models.Dtos
{
    public class PostDto
    {
        public string content { get; set; }
        public string cathegory { get; set; }
        public List<CommentsTable>? comments { get; set; } = new List<CommentsTable>();
        public List<PostsToTagsTable> postToTags { get; set; } = new List<PostsToTagsTable>();
        public List<PostsToCathegoriesTable> postToCathegory { get; set; }
        public DateTime creationDate { get; set; }

    }
}
