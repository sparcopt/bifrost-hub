namespace BifrostHub.Application.Features.GameEvents.Dto;

public class PlayerStats
{
    public Guid Id { get; }
    
    public string CharacterId { get; }
    
    public float Health { get; }
    
    public float MaxHealth { get; }
    
    public float Stamina { get; }

    public PlayerStats(Guid id, string characterId, float health, float maxHealth, float stamina)
    {
        Id = id;
        CharacterId = characterId;
        Health = health;
        MaxHealth = maxHealth;
        Stamina = stamina;
    }
}