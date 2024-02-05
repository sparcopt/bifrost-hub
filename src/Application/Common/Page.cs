namespace BifrostHub.Application.Common;

public class Page<T>
{
    public int Number { get; }
    public int TotalPages { get; }
    public int TotalItems { get; }
    public IEnumerable<T> Entries { get; }

    public Page(int number, int totalPages, int totalItems, IEnumerable<T> entries)
    {
        Number = number;
        TotalPages = totalPages;
        TotalItems = totalItems;
        Entries = entries;
    }
}