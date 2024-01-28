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

    protected async Task<IEnumerable<TPoco>> Find()
    {
        return await collection.Find(_ => true).ToListAsync();
    }
}