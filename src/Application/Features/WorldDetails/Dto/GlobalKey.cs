namespace BifrostHub.Application.Features.WorldDetails.Dto;

public class GlobalKey
{
    public string Name { get; }

    public string Value { get; }

    public GlobalKey(string name, string value)
    {
        Name = name;
        Value = value;
    }
}