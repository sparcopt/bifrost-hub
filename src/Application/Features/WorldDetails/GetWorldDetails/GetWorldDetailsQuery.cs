namespace BifrostHub.Application.Features.WorldDetails.GetWorldDetails;

using Common.Interfaces.Gateways;
using Dto;

public class GetWorldDetailsQuery
{ }

public static class GetPlayersQueryHandler
{
    public static async Task<WorldDetails> Handle(GetWorldDetailsQuery query, IOdinEyeApiClient client)
    {
        return await client.GetWorldDetails();
    }
}