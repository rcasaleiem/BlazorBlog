using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Tables
{
    public class PostsTable : GenericTable
    {
        [Required]
        public string content { get; set; }
        [Required]
        public string cathegory { get; set; }
        public string? tags { get; set; }
        public List<CommentsTable>? comments { get; set; } = new List<CommentsTable>();

    }
}
