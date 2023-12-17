namespace Web.Application.Extensions;

using Models;

public static class PlayerMappings
{
    public static Player ToModel(this OdinEye.Models.Api.Player player) =>
        new Player
        {
            Id = player.Id,
            SteamId = player.SteamId,
            Name = player.Name,
            Health = player.Health,
            MaxHealth = player.MaxHealth,
            Stamina = player.Stamina
        };
    
    public static Player ToModel(this OdinEye.Models.Proto.Player player) =>
        new Player
        {
            Id = player.Id,
            SteamId = player.SteamId,
            Name = player.Name,
            Health = player.Health,
            MaxHealth = player.MaxHealth,
            Stamina = player.Stamina
        };
}