namespace BifrostHub.Application.Features.Players.Dto;

public static class MappingExtensions
{
    public static Player ToDto(this Domain.Player player) =>
        new Player(
            player.Id,
            player.Name,
            player.SteamId,
            player.IsOnline,
            player.LastOnlineDate,
            player.CreatedDate,
            player.UpdatedDate);
}