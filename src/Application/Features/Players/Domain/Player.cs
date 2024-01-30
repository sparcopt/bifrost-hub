namespace BifrostHub.Application.Features.Players.Domain;

public class Player
{
    public Guid Id { get; }
    public string Name { get; }
    public string SteamId { get; }
    public OnlineStatus OnlineStatus { get; }
    public DateTime LastOnlineDate { get; }
    public DateTime CreatedDate { get; }
    public DateTime UpdatedDate { get; }

    public Player(Guid id, string name, string steamId)
    {
        Id = id;
        Name = name;
        SteamId = steamId;
        OnlineStatus = OnlineStatus.Online;
        LastOnlineDate = DateTime.UtcNow;
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;;
    }
    
    private Player(
        Guid id,
        string name,
        string steamId,
        OnlineStatus onlineStatus,
        DateTime lastOnlineDate,
        DateTime createdDate,
        DateTime updatedDate)
    {
        Id = id;
        Name = name;
        SteamId = steamId;
        OnlineStatus = onlineStatus;
        LastOnlineDate = lastOnlineDate;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public static Player Load(
        Guid id,
        string name,
        string steamId,
        OnlineStatus onlineStatus,
        DateTime lastOnlineDate,
        DateTime createdDate,
        DateTime updatedDate) =>
        new Player(id, name, steamId, onlineStatus, lastOnlineDate, createdDate, updatedDate);
}