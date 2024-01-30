namespace BifrostHub.Application.Features.GameEvents.Dto;

public static class PlayerExtensions
{
    public static Players.Dto.OnlinePlayer ToDto(this Player player) =>
        new Players.Dto.OnlinePlayer(
            player.Id,
            player.CharacterId,
            player.SteamId,
            player.Name,
            player.Health,
            player.MaxHealth,
            player.Stamina);
}