namespace BifrostHub.Application.Features.GameEvents.Dto;

public class WorldStats
{
    public int DayNumber { get; }
    
    public string DayCycle { get; }

    public WorldStats(int dayNumber, string dayCycle)
    {
        DayNumber = dayNumber;
        DayCycle = dayCycle;
    }
}