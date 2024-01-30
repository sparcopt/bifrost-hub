namespace BifrostHub.Application.Features.Players.Dto;

public static class PlayerExtensions
{
    public static int GetHealthAsInteger(this OnlinePlayer onlinePlayer) =>
        (int)Math.Ceiling(onlinePlayer.Health);
    
    public static int GetMaxHealthAsInteger(this OnlinePlayer onlinePlayer) =>
        (int)Math.Ceiling(onlinePlayer.MaxHealth);
    
    public static int GetStaminaAsInteger(this OnlinePlayer onlinePlayer) =>
        (int)Math.Ceiling(onlinePlayer.Stamina);

    public static float GetHealthPercentage(this OnlinePlayer onlinePlayer) =>
        onlinePlayer.Health * 100 / onlinePlayer.MaxHealth;
}