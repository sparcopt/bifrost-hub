namespace BifrostHub.Application.Features.Players.Domain;

public class Player
{
    public Guid Id { get; }
    public string Name { get; }
    public string SteamId { get; }
    public bool IsOnline { get; private set; }
    public DateTime LastOnlineDate { get; private set; }
    public DateTime CreatedDate { get; }
    public DateTime UpdatedDate { get; private set; }

    public Player(Guid id, string name, string steamId)
    {
        Id = id;
        Name = name;
        SteamId = steamId;
        IsOnline = true;
        LastOnlineDate = DateTime.UtcNow;
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;;
    }
    
    private Player(
        Guid id,
        string name,
        string steamId,
        bool isOnline,
        DateTime lastOnlineDate,
        DateTime createdDate,
        DateTime updatedDate)
    {
        Id = id;
        Name = name;
        SteamId = steamId;
        IsOnline = isOnline;
        LastOnlineDate = lastOnlineDate;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public static Player Load(
        Guid id,
        string name,
        string steamId,
        bool isOnline,
        DateTime lastOnlineDate,
        DateTime createdDate,
        DateTime updatedDate) =>
        new Player(id, name, steamId, isOnline, lastOnlineDate, createdDate, updatedDate);

    public void SetAsOnline()
    {
        IsOnline = true;
        LastOnlineDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }
    
    public void SetAsOffline()
    {
        IsOnline = false;
        LastOnlineDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }
}