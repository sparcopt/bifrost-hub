namespace BifrostHub.Infrastructure.Repositories.Players;

using Application.Common;
using Application.Common.Interfaces.Repositories;
using Application.Features.Players.GetAllPlayers;
using MongoDB.Driver;
using Pocos;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Domain = Application.Features.Players.Domain;
using SortDirection = Application.Common.SortDirection;

public class PlayerRepository : Repository<Player>, IPlayerRepository
{
    private const string CollectionName = "players";

    public PlayerRepository(IMongoDatabase database) : base(database, CollectionName)
    {
        ConfigureCollection(CreateIndexes);
    }

    public async Task Save(Domain.Player player) => await Upsert(player.ToPoco());

    public async Task<Domain.Player> GetById(Guid id) => (await FirstOrDefault(p => p.Id == id))?.ToDomain();
    public async Task<PagedResult<Domain.Player>> Search(
        string name,
        bool? isOnline = null,
        Sort<PlayerSortField> sort = null,
        int page = 1,
        int pageSize = 60)
    {
        var filterDefinition = BuildFilter(name, isOnline);
        var sortDefinition = BuildSort(sort);
        var players = await Find(filterDefinition, sortDefinition, page, pageSize);
        var count = await Count(filterDefinition);

        return new PagedResult<Domain.Player>(
            page,
            pageSize,
            count,
            players.Select(p => p.ToDomain()));
    }

    private FilterDefinition<Player> BuildFilter(string name, bool? isOnline)
    {
        var builder = Builders<Player>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrEmpty(name))
        {
            /* Remarks
            - Player collection is not expected to grow out of control
            - Regex provides a better search experience than the default text/stopword Mongo search
            - By using a left anchor (^{name}), a full index scan is avoided
              - This limits the search to the first word, which is okay for player names
            */
            var regex = new Regex($"^{name.ToLowerInvariant()}");
            filter = builder.Regex(p => p.NameToken, regex);
        }
        
        if (isOnline != null)
        {
            filter &= builder.Eq(p => p.IsOnline, isOnline);
        }
        
        return filter;
    }

    private SortDefinition<Player> BuildSort(Sort<PlayerSortField> sort)
    {
        if (sort is null)
        {
            return null;
        }
        
        Expression<Func<Player, object>> field = sort.Field switch
        {
            PlayerSortField.Name => player => player.NameToken,
            PlayerSortField.IsOnline => player => player.IsOnline
        };
        
        var builder = Builders<Player>.Sort;
        return sort.Direction switch
        {
            SortDirection.Ascending => builder.Ascending(field),
            SortDirection.Descending => builder.Descending(field)
        };
    }

    private void CreateIndexes(IMongoCollection<Player> collection)
    {
        var onlineNameIndex = Builders<Player>.IndexKeys
            .Ascending(x => x.IsOnline)
            .Ascending(x => x.NameToken);
        collection.Indexes.CreateOne(new CreateIndexModel<Player>(onlineNameIndex));
        var nameOnlineIndex = Builders<Player>.IndexKeys
            .Ascending(x => x.NameToken)
            .Ascending(x => x.IsOnline);
        collection.Indexes.CreateOne(new CreateIndexModel<Player>(nameOnlineIndex));
    }
}