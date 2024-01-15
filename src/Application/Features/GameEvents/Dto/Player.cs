namespace BifrostHub.Application.Features.GameEvents.Dto;

public class Player
{
    public string Id { get; }

    public string SteamId { get;}

    public string Name { get;}

    public float Health { get;}

    public float MaxHealth { get;}

    public float Stamina { get;}

    public Player(string id, string steamId, string name, float health, float maxHealth, float stamina)
    {
        Id = id;
        SteamId = steamId;
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
        Stamina = stamina;
    }
}