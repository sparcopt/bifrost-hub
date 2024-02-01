namespace BifrostHub.Infrastructure.Repositories.Players;

using Application.Common;
using Application.Common.Interfaces.Repositories;
using MongoDB.Driver;
using Pocos;
using Domain = Application.Features.Players.Domain;

public class PlayerRepository : Repository<Player>, IPlayerRepository
{
    private const string CollectionName = "players";
    private readonly IMongoCollection<Player> collection;
    
    public PlayerRepository(IMongoDatabase database) : base(database, CollectionName)
    { }

    public async Task Save(Domain.Player player) => await Upsert(player.ToPoco());

    public async Task<Domain.Player> GetById(Guid id) => (await FirstOrDefault(p => p.Id == id))?.ToDomain();
    public async Task<PagedResult<Domain.Player>> Search(string name, bool? isOnline = null, int page = 1, int pageSize = 60)
    {
        var builder = Builders<Player>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrEmpty(name))
        {
            filter = builder.Eq(p => p.Name, name);
        }
        
        if (isOnline != null)
        {
            filter &= builder.Eq(p => p.IsOnline, isOnline);
        }

        var players = await Find(filter, page, pageSize);
        var count = await Count(filter);

        return new PagedResult<Domain.Player>(
            page,
            pageSize,
            count,
            players.Select(p => p.ToDomain()));
    }
}