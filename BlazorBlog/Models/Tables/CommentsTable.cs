using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Tables
{
    public class CommentsTable : GenericTable
    {
        [Required]
        public string content { get; set; }
        [Required]
        public int authorId { get; set; }
        [Required]
        public int postId { get; set; }

        public int? responseToCommentId { get; set; }              // FK

        public virtual UsersTable author { get; set; }             // Navigation
        public virtual PostsTable post { get; set; }               // navigation
        public virtual CommentsTable? responseToComment { get; set; }          // navigation
        public virtual List<CommentsTable> responsesToComment { get; set; } = new(); // navigation
    }
}
