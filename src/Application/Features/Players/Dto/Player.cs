namespace BifrostHub.Application.Features.Players.Dto;

public class Player
{
    public Guid Id { get; }
    public string Name { get; }
    public string SteamId { get; }
    public bool IsOnline { get; private set; }
    public DateTime LastOnlineDate { get; private set; }
    public DateTime CreatedDate { get; }
    public DateTime UpdatedDate { get; private set; }

    public Player(
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
}