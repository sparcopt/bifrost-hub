namespace BifrostHub.Application.Common;

public class Sort<TSortField> where TSortField : struct
{
    public TSortField Field { get; }
    public SortDirection Direction { get; }

    public Sort(TSortField field, SortDirection direction)
    {
        Field = field;
        Direction = direction;
    }
}