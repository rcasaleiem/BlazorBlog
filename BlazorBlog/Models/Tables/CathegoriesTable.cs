namespace BlazorBlog.Models.Tables
{
    public class CathegoriesTable : GenericTable
    {
        public string cathegory {  get; set; }
        public virtual List<PostsToCathegoriesTable> PostToCathegory { get; set; }
    }
}
