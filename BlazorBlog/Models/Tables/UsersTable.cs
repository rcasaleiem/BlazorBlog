using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Tables
{
    public class UsersTable : GenericTable
    {
        [Required] 
        [StringLength(100)]
        public string username {  get; set; }
        [Required] 
        [StringLength(100)]
        public string password { get; set; }
        [Required]
        [StringLength(20)]
        public bool role { get; set; }
        public virtual List<CommentsTable> comments { get; set; } = new List<CommentsTable>();

    }
}
