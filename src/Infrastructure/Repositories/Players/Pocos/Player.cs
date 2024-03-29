﻿namespace BifrostHub.Infrastructure.Repositories.Players.Pocos;

public class Player : IPoco
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string SteamId { get; set; }
    public bool IsOnline { get; set; }
    public DateTime LastOnlineDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string NameToken { get; set; }
}