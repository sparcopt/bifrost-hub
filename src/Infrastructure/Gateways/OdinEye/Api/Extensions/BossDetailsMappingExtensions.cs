namespace BifrostHub.Infrastructure.Gateways.OdinEye.Api.Extensions;

using global::OdinEye.Models.Api;
using Dto = Application.Features.BossDetails.Dto;

public static class BossDetailsMappingExtensions
{
    public static Dto.BossDetails ToDto(this BossDetails bossDetails) =>
        new (bossDetails.ActiveBosses, bossDetails.Bosses.Select(b => b.ToDto()));

    public static Dto.Boss ToDto(this Boss boss) => new (boss.Key, boss.Name, boss.IsDefeated);
}