namespace BifrostHub.Application.Features.BossDetails.Dto;

public class BossDetails
{
    public int ActiveBosses { get; }

    public ICollection<Boss> Bosses { get; }

    public BossDetails(int activeBosses, IEnumerable<Boss> bosses)
    {
        ActiveBosses = activeBosses;
        Bosses = bosses.ToArray();
    }
}