using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Models.Dtos
{
    public class PostInsertUpdateDto
    {
        public int id { get; set; }
        public string content { get; set; }
        public List<PostToTagDto> tags { get; set; }
        public List<PostToCathegoryDto> cathegories { get; set; }
    }
}
