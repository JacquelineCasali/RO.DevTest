public class PaginationHelper
{
    public static IQueryable<T> Paginate<T>(IQueryable<T> query, int page, int pageSize, string sortBy, bool descending = false)
    {
        // Ordenação
        if (!string.IsNullOrEmpty(sortBy))
        {
            query = descending 
                ? query.OrderByDescending(x => EF.Property<object>(x, sortBy)) 
                : query.OrderBy(x => EF.Property<object>(x, sortBy));
        }

        // Paginação
        return query.Skip((page - 1) * pageSize).Take(pageSize);
    }
}
