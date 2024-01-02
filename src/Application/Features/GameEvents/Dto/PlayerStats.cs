namespace BifrostHub.Application.Features.GameEvents.Dto;

public class PlayerStats
{
    public string Id { get; }
    
    public float Health { get; }
    
    public float MaxHealth { get; }
    
    public float Stamina { get; }

    public PlayerStats(string id, float health, float maxHealth, float stamina)
    {
        Id = id;
        Health = health;
        MaxHealth = maxHealth;
        Stamina = stamina;
    }
}