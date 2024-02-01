namespace BifrostHub.Application.Features.Players.GetAllPlayers;

using Common;
using Common.Interfaces.Repositories;
using Dto;

public class GetAllPlayersQuery
{
    public string Name { get; set; }
    public bool? IsOnline { get; set; }
}

public static class GetAllPlayersQueryHandler
{
    // Returning IEnumerable<> triggers Wolverine
    // No routes can be determined for Envelope #018d61f3-5b6f-47b4-8da7-fa109dde1fcb (Player) ??
    public static async Task<Page<Player>> Handle(GetAllPlayersQuery query, IPlayerRepository playerRepository)
    {
        var pagedResult = await playerRepository.Search(query.Name, query.IsOnline);

        return new Page<Player>(
            pagedResult.PageNumber,
            pagedResult.TotalPages,
            pagedResult.TotalItems,
            pagedResult.Entries.Select(x => x.ToDto()));
    }
}