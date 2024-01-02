namespace BifrostHub.Application.Features.BossDetails.GetBossDetails;

using Common.Interfaces.Gateways;
using Dto;

public class GetBossDetailsQuery
{ }

public static class GetBossDetailsQueryHandler
{
    public static async Task<BossDetails> Handle(GetBossDetailsQuery query, IOdinEyeApiClient client)
    {
        var bossDetails = await client.GetBossDetails();
        var bossMetadata = GetBossMetadata().ToList();
        
        foreach (var boss in bossDetails.Bosses)
        {
            var metadata = bossMetadata.First(b => b.Key == boss.Key);
            boss.AddMetadata(metadata.Description, metadata.Image);
        }

        return bossDetails;
    }
    
    private static IEnumerable<BossMetadata> GetBossMetadata()
    {
        return new[]
        {
            new BossMetadata
            {
                Key = "eikthyr",
                Description = "His antlers are branches of iron, they crack the rocks and bring down mountains. His hooves are the sound of thunder. His voice a howling gale.",
                Image = "bosses/eikthyr.png"
            },
            new BossMetadata
            {
                Key = "gdking",
                Description = "First of the Forest, King-in-the-Wood, Lord over those who dwell at his feet. His roots will grow where cities once stood, their blood his wine, their flesh his meat.",
                Image = "bosses/the_elder.png"
            },
            new BossMetadata
            {
                Key = "bonemass",
                Description = "Wanderer, look to your feet, that tread upon our tomb. One thousand bones without their meat, will drag you to your doom.",
                Image = "bosses/bonemass.png"
            },
            new BossMetadata
            {
                Key = "dragon",
                Description = "Black wings across the moon and sun, down from the mountain our mother comes. Her weeping tears will fall like rain, her voice will call us home again.",
                Image = "bosses/moder.png"
            },
            new BossMetadata
            {
                Key = "goblinking",
                Description = "Long ages past, he wore a crown, beneath a blood-red sky. Now naught is left of all he was, but his spirit cannot die.",
                Image = "bosses/yagluth.png"
            },
            new BossMetadata
            {
                Key = "queen",
                Description = "Born in armour, mother of many, Queen without crown, ruler beneath.",
                Image = "bosses/the_queen.png"
            }
        };
    }
}