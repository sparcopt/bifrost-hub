namespace BifrostHub.Infrastructure.Gateways.OdinEye.WebSockets.Extensions;

using global::OdinEye.Models.Proto;
using Dto = Application.Features.GameEvents.Dto;

public static class GameStatsSnapshotMappingExtensions
{
    public static Dto.GameStatsSnapshot ToDto(this GameStatsSnapshot snapshot) =>
        new(snapshot.PlayerStats.Select(p => p.ToDto()), snapshot.WorldStats.ToDto());

    public static Dto.PlayerStats ToDto(this PlayerStats playerStats) =>
        new (playerStats.Id, playerStats.CharacterId, playerStats.Health, playerStats.MaxHealth, playerStats.Stamina);

    public static Dto.WorldStats ToDto(this WorldStats worldStats) =>
        new(worldStats.DayNumber, worldStats.DayCycle);
}