using AutoMapper;
using System.ComponentModel;

namespace BlazorBlog.Services
{
    public class ResultListService
    {
        private readonly ILogger<ResultListService> _logger;
        private readonly IMapper _mapper;

    }

    public enum OrderType
    {
        /// <summary>
        ///     cresente
        /// </summary>
        Ascending = 0,

        /// <summary>
        ///     Decrescente
        /// </summary>
        Descending = 1
    }

    public class ListFilter
    {
        private bool? _downloadXSL;
        private string _order;
        private int? _page;


        /// <summary>
        ///     Ordinamento da applicare (possono essere inserite più colonne separate da virgole)
        /// </summary>
        public string? OrderColumns { get; set; }


        /// <summary>
        ///     Pagina da visualizzare (default 1)
        /// </summary>
        [DefaultValue(1)]
        public int? Page
        {
            get => _page ?? CurrentPage ?? 1;
            set => _page = value;
        }

        /// <summary>
        ///     Pagina attuale
        /// </summary>
        public int? CurrentPage { get; set; }

        /// <summary>
        ///     Numero massimo di elementi visualizzati per pagina (default 20)
        /// </summary>
        [DefaultValue(20)]
        public int? RecordsPerPage { get; set; } = 20;

        public bool? DownloadCsv { get; set; }

        public bool? DownloadXLS { get; set; }
        public bool? DownloadPDF { get; set; }
        public List<GridFilters?> GridFilters { get; set; } = new();
        public List<FilterGroup> FilterGroups { get; set; } = new();

        public void ResetDownloads()
        {
            _downloadXSL = false;
            DownloadPDF = false;
            DownloadCsv = false;
        }

        public ListFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListFilter"/> class with the specified number of records per page.
        /// </summary>
        /// <param name="recordsPerPage">
        /// The number of records to display per page. Use 0 to indicate no pagination.
        /// </param>
        public ListFilter(int recordsPerPage)
        {
            RecordsPerPage = recordsPerPage;
        }

        /// <summary>
        ///     Adds a filter to the current list of filters.
        /// </summary>
        /// <param name="column">The name of the column to which the filter will be applied.</param>
        /// <param name="filterOperator">
        ///     The operator used for filtering (e.g., "==", "!=", ">", "<").</param>
        /// <param name="value">The value to filter by. Can be <c>null</c>.</param>
        /// <returns>The current <see cref="ListFilter" /> instance with the added filter.</returns>
        public ListFilter AddFilter(string column, string filterOperator, string? value)
        {
            GridFilters.Add(new GridFilters
            {
                FilterColumn = column,
                FilterOperator = filterOperator,
                FilterValue = value
            });

            return this;
        }

        /// <summary>
        ///     Adds a filter group to the current list of filter groups.
        /// </summary>
        /// <param name="filterGroup">
        ///     The <see cref="FilterGroup" /> instance to add. This represents a group of filters combined using a logical
        ///     operator.
        /// </param>
        /// <returns>
        ///     The current <see cref="ListFilter" /> instance with the added filter group, allowing for method chaining.
        /// </returns>
        public ListFilter AddFilterGroup(FilterGroup filterGroup)
        {
            FilterGroups.Add(filterGroup);
            return this;
        }

        /// <summary>
        ///     Sets the order of columns for sorting the data.
        /// </summary>
        /// <param name="orderColumns">
        ///     A string representing the columns to sort by, typically in a comma-separated format.
        /// </param>
        /// <returns>
        ///     The current <see cref="ListFilter" /> instance with the specified order applied, allowing for method chaining.
        /// </returns>
        public ListFilter SetOrder(string orderColumns)
        {
            OrderColumns = orderColumns;
            return this;
        }

        /// <summary>
        ///     Sets the current page number for pagination.
        /// </summary>
        /// <param name="page">
        ///     The page number to set. Must be a positive integer.
        /// </param>
        /// <returns>
        ///     The current <see cref="ListFilter" /> instance with the specified page number applied, allowing for method
        ///     chaining.
        /// </returns>
        public ListFilter SetPage(int page)
        {
            Page = page;
            return this;
        }
    }

    public class FilterGroup
    {
        public string LogicOperator { get; set; } = "OR"; // OR/AND
        public List<GridFilters> Filters { get; set; } = new();
    }

    public class GridFilters
    {
        public GridFilters()
        {
        }

        public GridFilters(string? filterOperator, string? filterColumn, string? filterValue)
        {
            FilterOperator = filterOperator;
            FilterColumn = filterColumn;
            FilterValue = filterValue;
        }

        public string? FilterOperator { get; set; }
        public string? FilterColumn { get; set; }
        public string? FilterValue { get; set; }
    }
}
