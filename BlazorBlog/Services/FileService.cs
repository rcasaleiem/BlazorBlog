namespace BlazorBlog.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string PostsDirectoryPath => Path.Combine(_env.ContentRootPath, "LocalFiles", "Posts");
        public string CommentsDirectoryPath => Path.Combine(_env.ContentRootPath, "LocalFiles", "Comments");

        public void WritePost(string content, string title)
        {
            // Crea la cartella se non esiste
            Directory.CreateDirectory(PostsDirectoryPath);

            // Percorso completo del file
            string filePath = Path.Combine(PostsDirectoryPath, $"{title}.txt");

            // Scrivi il file
            File.WriteAllText(filePath, $"{title}\n\n{content}");
        }

        //public void WriteComment(string content)
        //{
        //    // Crea la cartella se non esiste
        //    Directory.CreateDirectory(CommentsDirectoryPath);

        //    // Percorso completo del file
        //    string filePath = Path.Combine(PostsDirectoryPath, $"{title}.txt");

        //    // Scrivi il file
        //    File.WriteAllText(filePath, $"{title}\n\n{content}");
        //}


    }
}
