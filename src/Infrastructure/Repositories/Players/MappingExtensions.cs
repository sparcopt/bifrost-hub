namespace BifrostHub.Infrastructure.Repositories.Players;

using Pocos;
using Domain = Application.Features.Players.Domain;

public static class MappingExtensions
{
    public static Player ToPoco(this Domain.Player player) =>
        new Player
        {
            Id = player.Id,
            Name = player.Name,
            SteamId = player.SteamId,
            IsOnline = player.IsOnline,
            LastOnlineDate = player.LastOnlineDate,
            CreatedDate = player.CreatedDate,
            UpdatedDate = player.UpdatedDate
        };

    public static Domain.Player ToDomain(this Player player) =>
        Domain.Player.Load(
            player.Id,
            player.Name,
            player.SteamId,
            player.IsOnline,
            player.LastOnlineDate,
            player.CreatedDate,
            player.UpdatedDate);
}