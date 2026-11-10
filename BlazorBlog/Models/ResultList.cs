namespace BlazorBlog.Models
{
    public class ResultList<T>
    {
        public ResultList()
        {
            Count = 0;
            List = new();
            Page = 1;
            PageCount = 1;
            RecordsPerPage = 10;
            FirstElement = 0;
            LastElement = 0;


        }



        /// <summary>
        /// Numero totale elementi
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Numero di pagina estratta
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// primo elemento estratto
        /// </summary>
        public int FirstElement { get; set; }

        /// <summary>
        /// Ultimo elemento estratto
        /// </summary>
        public int LastElement { get; set; }

        /// <summary>
        /// Numero di elementi per pagina
        /// </summary>
        public int RecordsPerPage { get; set; }

        /// <summary>
        /// Numero totale di pagine
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Informazioni relativi alla ricerca effettuata
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Lista degli oggetti restituiti
        /// </summary>
        public List<T> List { get; set; }


        /// <summary>
        /// Ordinamento effettuato sulla lista
        /// </summary>
        public string Order { get; set; }

        public byte[] CSV { get; set; }
        public byte[] Excel { get; set; }
        public byte[] Pdf { get; set; }
    }
}
