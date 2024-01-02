namespace BifrostHub.Application.Features.ServerDetails.GetServerDetails;

using Common.Interfaces.Gateways;
using Dto;

public class GetServerDetailsQuery
{ }

public static class GetPlayersQueryHandler
{
    public static async Task<ServerDetails> Handle(GetServerDetailsQuery query, IOdinEyeApiClient client)
    {
        return await client.GetServerDetails();
    }
}