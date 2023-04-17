namespace eFitnessAPI.Helper
{
    public class PagedResult
    {
        public virtual int TotalPages { get; set; }
        public virtual int TotalItems { get; set; }
        public virtual int CurrentPage { get; set; }
    }
}
