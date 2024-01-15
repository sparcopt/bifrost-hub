namespace BifrostHub.Application.Features.Players.Dto;

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