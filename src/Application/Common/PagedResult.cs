namespace BifrostHub.Application.Common;

public class PagedResult<T>
{
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalItems { get; }
    public IEnumerable<T> Entries { get; }

    public PagedResult(int pageNumber, int pageSize, int totalItems, IEnumerable<T> entries)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
        TotalItems = totalItems;
        Entries = entries;
    }
}