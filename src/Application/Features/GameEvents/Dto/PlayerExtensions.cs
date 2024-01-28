namespace BifrostHub.Application.Features.GameEvents.Dto;

public static class PlayerExtensions
{
    public static Players.Dto.Player ToDto(this Player player) =>
        new Players.Dto.Player(
            player.Id,
            player.CharacterId,
            player.SteamId,
            player.Name,
            player.Health,
            player.MaxHealth,
            player.Stamina);
}