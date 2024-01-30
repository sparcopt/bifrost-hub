namespace BifrostHub.Infrastructure.Gateways.OdinEye.Api.Extensions;

using global::OdinEye.Models.Api;
using Dto = Application.Features.Players.Dto;

public static class PlayerMappingExtensions
{
    public static Dto.OnlinePlayer ToDto(this Player player) =>
        new(
            player.Id,
            player.CharacterId,
            player.SteamId,
            player.Name,
            player.Health,
            player.MaxHealth,
            player.Stamina);
}