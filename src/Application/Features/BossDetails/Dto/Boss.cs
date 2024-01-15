namespace BifrostHub.Application.Features.BossDetails.Dto;

public class Boss
{
    public string Key { get; }

    public string Name { get; }

    public bool IsDefeated { get; }
    
    public string Description { get; private set; }
    
    public string Image { get; private set; }
    
    public Boss(string key, string name, bool isDefeated)
    {
        Key = key;
        Name = name;
        IsDefeated = isDefeated;
    }

    public void AddMetadata(string description, string image)
    {
        Description = description;
        Image = image;
    }
}