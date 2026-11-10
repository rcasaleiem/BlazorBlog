namespace BlazorBlog.Models.Tables
{
    public class PostsToTagsTable : GenericTable
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public virtual PostsTable? post { get; set; }  //\\navigation
        public virtual TagsTable? tag { get; set; }    //\\navigation
    }
}

