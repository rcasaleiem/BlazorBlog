using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Tables
{
    public class CommentsTable : GenericTable
    {
        [Required]
        public string content { get; set; }
        [Required]
        public UsersTable author { get; set; }
        [Required]
        public int authorId { get; set; }
        [Required]
        public PostsTable post {  get; set; }
        [Required]
        public int postId { get; set; }
        public int? rispostaA { get; set; }
    }
}
