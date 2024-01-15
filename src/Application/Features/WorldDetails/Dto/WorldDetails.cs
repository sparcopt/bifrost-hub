namespace BifrostHub.Application.Features.WorldDetails.Dto;

public class WorldDetails
{
    public int DayNumber { get; }

    public string DayCycle { get; }

    public string WorldName { get; }

    public string SeedName { get; }

    public IEnumerable<string> WorldKeys { get; }

    public IEnumerable<GlobalKey> GlobalKeys { get; }

    public WorldDetails(int dayNumber, string dayCycle, string worldName, string seedName, IEnumerable<string> worldKeys, IEnumerable<GlobalKey> globalKeys)
    {
        DayNumber = dayNumber;
        DayCycle = dayCycle;
        WorldName = worldName;
        SeedName = seedName;
        WorldKeys = worldKeys;
        GlobalKeys = globalKeys;
    }
}