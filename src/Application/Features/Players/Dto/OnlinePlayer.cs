namespace BifrostHub.Application.Features.Players.Dto;

public class OnlinePlayer
{
    public Guid Id { get; private set; }
    
    public string CharacterId { get; private set; }

    public string SteamId { get; }
    
    public string SteamUsername { get; private set; }
    
    public string SteamAvatarPath { get; private set; }

    public string Name { get; }

    public float Health { get; private set; }

    public float MaxHealth { get; private set; }

    public float Stamina { get; private set; }
    

    public OnlinePlayer(Guid id, string characterId, string steamId, string name, float health, float maxHealth, float stamina)
    {
        Id = id;
        CharacterId = characterId;
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
}