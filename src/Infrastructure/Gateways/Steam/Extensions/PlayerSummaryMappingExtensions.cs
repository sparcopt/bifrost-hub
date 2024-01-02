namespace BifrostHub.Infrastructure.Gateways.Steam.Extensions;

using Application.Features.Players.Dto;
using Models;

public static class PlayerSummaryMappingExtensions
{
    public static SteamUserProfile ToDto(this PlayerSummary playerSummary) =>
        new(
            playerSummary.SteamId,
            playerSummary.ProfileUrl,
            playerSummary.Username,
            playerSummary.Avatar);
}