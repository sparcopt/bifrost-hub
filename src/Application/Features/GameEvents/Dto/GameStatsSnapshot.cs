namespace BifrostHub.Application.Features.GameEvents.Dto;

public class GameStatsSnapshot
{
    public IEnumerable<PlayerStats> PlayerStats { get; } 
    
    public WorldStats WorldStats { get; }

    public GameStatsSnapshot(IEnumerable<PlayerStats> playerStats, WorldStats worldStats)
    {
        PlayerStats = playerStats;
        WorldStats = worldStats;
    }
}