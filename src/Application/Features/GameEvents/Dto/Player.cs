namespace BifrostHub.Application.Features.GameEvents.Dto;

public class Player
{
    public Guid Id { get; }
    
    public string CharacterId { get; }

    public string SteamId { get;}

    public string Name { get;}

    public float Health { get;}

    public float MaxHealth { get;}

    public float Stamina { get;}

    public Player(Guid id, string characterId, string steamId, string name, float health, float maxHealth, float stamina)
    {
        Id = id;
        CharacterId = characterId;
        SteamId = steamId;
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
        Stamina = stamina;
    }
}