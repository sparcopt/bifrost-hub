namespace BifrostHub.Web.UI.Extensions;

using Application.Common;

public static class SortDirectionExtensions
{
    public static SortDirection ToDomain(this MudBlazor.SortDirection direction) =>
        direction switch
        {
            MudBlazor.SortDirection.Ascending => SortDirection.Ascending,
            MudBlazor.SortDirection.Descending => SortDirection.Descending
        };
}