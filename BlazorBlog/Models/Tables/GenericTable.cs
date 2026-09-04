using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Tables
{
    public class GenericTable
    {
        [Required]
        private int Id { get; set; }
        [Required]
        private DateTime? CreationDate { get; set; }


    }
}
