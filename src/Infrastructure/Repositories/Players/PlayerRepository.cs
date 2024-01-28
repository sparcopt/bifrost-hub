namespace BifrostHub.Infrastructure.Repositories.Players;

using Application.Common.Interfaces.Repositories;
using MongoDB.Driver;
using Pocos;

public class PlayerRepository : Repository<Player>, IPlayerRepository
{
    private const string CollectionName = "players";
    private readonly IMongoCollection<Player> collection;
    
    public PlayerRepository(IMongoDatabase database) : base(database, CollectionName)
    { }

    public async Task Save()
    {
        var player = new Player { Id = Guid.NewGuid() };
        await Upsert(player);
    } 

    public async Task<Player> GetById(Guid id) => await FirstOrDefault(p => p.Id == id);

    public async Task<IEnumerable<Player>> Search() => await Find();
}