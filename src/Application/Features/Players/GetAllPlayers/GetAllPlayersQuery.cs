namespace BifrostHub.Application.Features.Players.GetAllPlayers;

using Common;
using Common.Interfaces.Repositories;
using Dto;

public class GetAllPlayersQuery
{
    public string Name { get; set; }
    public bool? IsOnline { get; set; }
    public Sort<PlayerSortField> Sort { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public static class GetAllPlayersQueryHandler
{
    public static async Task<Page<Player>> Handle(GetAllPlayersQuery query, IPlayerRepository playerRepository)
    {
        var pagedResult = await playerRepository.Search(query.Name, query.IsOnline, query.Sort, query.Page, query.PageSize);

        return new Page<Player>(
            pagedResult.PageNumber,
            pagedResult.TotalPages,
            pagedResult.TotalItems,
            pagedResult.Entries.Select(x => x.ToDto()));
    }
}