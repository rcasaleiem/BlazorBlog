using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Tables
{
    public class PostsTable : GenericTable
    {
        [Required]
        [StringLength(100)]
        public string content { get; set; }
        public virtual List<CommentsTable>? comments { get; set; } = new List<CommentsTable>();
        public virtual List<PostsToTagsTable> postToTags { get; set; } = new List<PostsToTagsTable>();
        public virtual List<PostsToCathegoriesTable> PostToCathegory { get; set; } = new List<PostsToCathegoriesTable>();
    }
}
