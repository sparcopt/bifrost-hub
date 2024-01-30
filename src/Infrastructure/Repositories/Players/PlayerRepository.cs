namespace BifrostHub.Infrastructure.Repositories.Players;

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
}