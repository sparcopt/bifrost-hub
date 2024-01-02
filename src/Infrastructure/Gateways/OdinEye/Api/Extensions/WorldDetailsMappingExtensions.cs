namespace BifrostHub.Infrastructure.Gateways.OdinEye.Api.Extensions;

using global::OdinEye.Models.Api;
using Dto = Application.Features.WorldDetails.Dto;

public static class WorldDetailsMappingExtensions
{
    public static Dto.WorldDetails ToDto(this WorldDetails worldDetails) =>
        new(
            worldDetails.DayNumber,
            worldDetails.DayCycle,
            worldDetails.WorldName,
            worldDetails.SeedName,
            worldDetails.WorldKeys,
            worldDetails.GlobalKeys.Select(k => k.ToDto()));

    public static Dto.GlobalKey ToDto(this GlobalKey globalKey) =>
        new(globalKey.Name, globalKey.Value);
}