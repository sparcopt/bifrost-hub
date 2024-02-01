namespace BifrostHub.Infrastructure.Repositories;

using MongoDB.Driver;
using System.Linq.Expressions;

public abstract class Repository<TPoco> where TPoco : class, IPoco
{
    private readonly IMongoCollection<TPoco> collection;
    private static ReplaceOptions replaceOptions = new() { IsUpsert = true };
    
    protected Repository(IMongoDatabase database, string collectionName)
    {
        collection = database.GetCollection<TPoco>(collectionName);
    }
    
    protected async Task Upsert(TPoco poco) => await collection.ReplaceOneAsync(p => p.Id == poco.Id, poco, replaceOptions);

    protected async Task Delete(Expression<Func<TPoco, bool>> filter) => await collection.DeleteOneAsync(filter);
    
    protected async Task<TPoco> FirstOrDefault(Expression<Func<TPoco, bool>> filter) => await collection.Find(filter).FirstOrDefaultAsync();

    protected async Task<IEnumerable<TPoco>> Find(
        FilterDefinition<TPoco> filter,
        SortDefinition<TPoco> sortDefinition = null,
        int? page = null,
        int? pageSize = null)
    {
        var query = collection.Find(filter);
        
        if (page != null && pageSize != null)
        {
            query.Skip((page - 1) * pageSize).Limit(pageSize);
        }

        if (sortDefinition != null)
        {
            query.Sort(sortDefinition);
        }
        
        return await query.ToListAsync();
    }
    
    protected async Task<int> Count(FilterDefinition<TPoco> filter) => (int)await collection.CountDocumentsAsync(filter);
}