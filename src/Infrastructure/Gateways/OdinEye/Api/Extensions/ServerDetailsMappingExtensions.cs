namespace BifrostHub.Infrastructure.Gateways.OdinEye.Api.Extensions;

using global::OdinEye.Models.Api;
using Dto = Application.Features.ServerDetails.Dto;

public static class ServerDetailsMappingExtensions
{
    public static Dto.ServerDetails ToDto(this ServerDetails serverDetails) =>
        new(serverDetails.MaxNumberOfPlayers, serverDetails.GameVersion, serverDetails.SteamAppId);
}