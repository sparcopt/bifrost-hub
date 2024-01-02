namespace BifrostHub.Application.Features.BossDetails.Dto;

public class Boss
{
    public string Key { get; }

    public string Name { get; }

    public bool IsDefeated { get; }
    
    public Boss(string key, string name, bool isDefeated)
    {
        Key = key;
        Name = name;
        IsDefeated = isDefeated;
    }
}