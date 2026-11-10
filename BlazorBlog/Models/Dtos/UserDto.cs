using BlazorBlog.Models.Tables;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Dtos
{
    public class UserDto
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool role { get; set; }
        public List<CommentsTable> comments { get; set; } = new List<CommentsTable>();
    }
}
