using MongoDB.Driver;
using PadelAPI.Models;

namespace PadelAPI.Repository
{
    public class PadelRepository : IPadelRepository
    {
        private readonly IMongoCollection<Padel> _collection;

        public PadelRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Padel>("PadelCollection");
        }

        public async Task<IEnumerable<Padel>> GetAllPadelSessionsAsync()
        {
            var filter = Builders<Padel>.Filter.Empty;
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<Padel> GetPadelSessionByIdAsync(Guid id)
        {
            var filter = Builders<Padel>.Filter.Eq(x => x.Id, id);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Padel> CreateNewPadelSessionAsync(Padel padel)
        {
            await _collection.InsertOneAsync(padel);
            return padel;
        }

        public async Task UpdatePadelSessionAsync(Padel padel)
        {
            var filter = Builders<Padel>.Filter.Eq(x => x.Id, padel.Id);
            await _collection.ReplaceOneAsync(filter, padel);
            return;
        }
    }
}
