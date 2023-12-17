namespace Web.Application.Models;

public class Player
{
    public string Id { get; set; }
    public string SteamId { get; set; }
    public string SteamUsername { get; set; }
    public string SteamAvatarPath { get; set; }
    public string Name { get; set; }
    public float Health { get; set; }
    public float MaxHealth { get; set; }
    public float Stamina { get; set; }
}

public static class PlayerExtensions
{
    public static int GetHealthAsInteger(this Player player) =>
        (int)Math.Ceiling(player.Health);
    
    public static int GetMaxHealthAsInteger(this Player player) =>
        (int)Math.Ceiling(player.MaxHealth);
    
    public static int GetStaminaAsInteger(this Player player) =>
        (int)Math.Ceiling(player.Stamina);

    public static float GetHealthPercentage(this Player player) =>
        player.Health * 100 / player.MaxHealth;
}