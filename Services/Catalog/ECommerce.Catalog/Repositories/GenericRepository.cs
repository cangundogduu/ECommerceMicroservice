using ECommerce.Catalog.Entities.Common;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ECommerce.Catalog.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public GenericRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _collection.Find(x=>x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _collection.FindOneAndReplaceAsync(x=>x.Id==entity.Id, entity);
        }
    }
}
