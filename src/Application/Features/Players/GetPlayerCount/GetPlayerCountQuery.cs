namespace BifrostHub.Application.Features.Players.GetPlayerCount;

using Common.Interfaces.Repositories;

public class GetPlayerCountQuery
{
    public bool? IsOnline { get; set; }
}

public static class GetPlayerCountQueryHandler
{
    public static Task<int> Handle(GetPlayerCountQuery query, IPlayerRepository playerRepository) =>
        playerRepository.GetTotalCount(query.IsOnline);
}