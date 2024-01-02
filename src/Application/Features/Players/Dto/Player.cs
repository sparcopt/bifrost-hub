namespace BifrostHub.Application.Features.Players.Dto;

public class Player
{
    public string Id { get; private set; }

    public string SteamId { get; }
    
    public string SteamUsername { get; private set; }
    
    public string SteamAvatarPath { get; private set; }

    public string Name { get; }

    public float Health { get; private set; }

    public float MaxHealth { get; private set; }

    public float Stamina { get; private set; }
    

    public Player(string id, string steamId, string name, float health, float maxHealth, float stamina)
    {
        Id = id;
        SteamId = steamId;
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
        Stamina = stamina;
    }

    public void SetSteamInfo(string username, string avatarPath)
    {
        SteamUsername = username;
        SteamAvatarPath = avatarPath;
    }

    public void UpdateStats(float health, float maxHealth, float stamina)
    {
        Health = health;
        MaxHealth = maxHealth;
        Stamina = stamina;
    }

    public void UpdateIdentifier(string id) => Id = id;
}