namespace BlazorBlog.Models.Tables
{
    public class TagsTable : GenericTable
    {
        public string Tag { get; set; }
        public virtual List<PostsToTagsTable> PostToTags { get; set; } = new List<PostsToTagsTable>();
    }
}
