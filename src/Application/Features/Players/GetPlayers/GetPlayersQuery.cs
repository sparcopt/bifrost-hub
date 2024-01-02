namespace BifrostHub.Application.Features.Players.GetPlayers;

using Common.Interfaces.Gateways;
using Dto;

public class GetPlayersQuery
{ }

public static class GetPlayersQueryHandler
{
    public static async Task<IEnumerable<Player>> Handle(GetPlayersQuery query, IOdinEyeApiClient client)
    {
        return await client.GetPlayers();
    }
}