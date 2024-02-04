namespace BifrostHub.Application.Common.Interfaces.Repositories;

using Features.Players.Domain;
using Features.Players.GetAllPlayers;

public interface IPlayerRepository
{
    Task Save(Player player);
    Task<Player> GetById(Guid id);
    Task<PagedResult<Player>> Search(int page, int pageSize, string name, bool? isOnline = null, Sort<PlayerSortField> sort = null);
}