namespace BifrostHub.Infrastructure.Repositories.Players.Pocos;

public class Player : IPoco
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string SteamId { get; set; }
    public OnlineStatus OnlineStatus { get; set; }
    public DateTime LastOnlineDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}