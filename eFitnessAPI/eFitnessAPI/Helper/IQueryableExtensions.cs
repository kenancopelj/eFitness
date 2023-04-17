namespace eFitnessAPI.Helper
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int skip, int pageSize, bool retrieveAll = false)
        {
            if (retrieveAll)
            {
                return query;
            }
            else
            {
                return query.Skip(skip).Take(pageSize);
            }
        }
    }
}
