namespace BifrostHub.Application.Common.Interfaces.Repositories;

using Features.Players.Domain;

public interface IPlayerRepository
{
    Task Save(Player player);
    Task<Player> GetById(Guid id);
}