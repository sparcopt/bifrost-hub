namespace BifrostHub.Application.Features.BossDetails.GetBossDetails;

using Common.Interfaces.Gateways;
using Dto;

public class GetBossDetailsQuery
{ }

public static class GetBossDetailsQueryHandler
{
    public static async Task<BossDetails> Handle(GetBossDetailsQuery query, IOdinEyeApiClient client)
    {
        return await client.GetBossDetails();
    }
}