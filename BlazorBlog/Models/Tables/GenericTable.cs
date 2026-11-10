using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Tables
{
    public class GenericTable
    {
        [Required]
         public int id { get; set; }
        [Required]
         public DateTime? creationDate { get; set; }
    }
}
