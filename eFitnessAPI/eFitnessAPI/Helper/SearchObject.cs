namespace eFitnessAPI.Helper
{
    public class SearchObject : PagedQuery
    {

        public SearchObject() : base()
        { }

        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }

        public bool RetrieveAll { get; set; }

        public string QuickSearch { get; set; }
    }
}
