namespace BifrostHub.Application.Common.Interfaces.Repositories;

using Features.Players.Domain;

public interface IPlayerRepository
{
    Task Save(Player player);
    Task<Player> GetById(Guid id);
    Task<PagedResult<Player>> Search(string name, bool? isOnline = null, int page = 1, int pageSize = 60);
}