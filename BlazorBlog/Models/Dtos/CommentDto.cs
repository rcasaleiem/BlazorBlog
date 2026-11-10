using BlazorBlog.Models.Tables;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Dtos
{
    public class CommentDto
    {
        public int commentId {  get; set; }
        public string content { get; set; }
        public string author { get; set; }
        public CommentsTable? RespondedComment { get; set; }
        public List<CommentsTable?> responsesToComment { get; set; }
    }
}
