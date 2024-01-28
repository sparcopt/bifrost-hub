namespace BifrostHub.Infrastructure.Gateways.OdinEye.WebSockets.Extensions;

using global::OdinEye.Models.Proto;
using Dto = Application.Features.GameEvents.Dto;

public static class GameEventMappingExtensions
{
    public static Dto.GameEvent ToDto(this GameEvent gameEvent) =>
        new(
            gameEvent.CreatedDate,
            gameEvent.Message,
            Enum.Parse<Dto.EventType>(gameEvent.Type.ToString()),
            gameEvent.Player?.ToDto(),
            gameEvent.Data);

    public static Dto.Player ToDto(this Player player) =>
        new(
            player.Id,
            player.CharacterId,
            player.SteamId,
            player.Name,
            player.Health,
            player.MaxHealth,
            player.Stamina);
}