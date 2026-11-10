using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BlazorBlog.Models.Tables
{
    public class PostsToCathegoriesTable : GenericTable
    {
        public int cathegoryId { get; set; }
        public int postId { get; set; }
        public virtual CathegoriesTable cathegory {  get; set; } //\\navigation
        public virtual PostsTable post {  get; set; }  //\\navigation
    }
}
