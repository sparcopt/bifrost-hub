namespace BifrostHub.Application.Common.Interfaces.Repositories;

using Features.Players.Domain;
using Features.Players.GetAllPlayers;

public interface IPlayerRepository
{
    Task Save(Player player);
    Task<Player> GetById(Guid id);
    Task<PagedResult<Player>> Search(string name, bool? isOnline = null, Sort<PlayerSortField> sort = null, int page = 1, int pageSize = 60);
}