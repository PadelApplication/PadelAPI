using MongoDB.Driver;
using PadelAPI.Models;

namespace PadelAPI.Repository
{
    public class PadelRepository : IPadelRepository
    {
        private readonly IMongoCollection<PadelSession> _collection;

        public PadelRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<PadelSession>("PadelCollection");
        }

        public async Task<IEnumerable<PadelSession>> GetAllPadelSessionsAsync()
        {
            var filter = Builders<PadelSession>.Filter.Empty;
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<PadelSession> GetPadelSessionByIdAsync(Guid id)
        {
            var filter = Builders<PadelSession>.Filter.Eq(x => x.Id, id);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<PadelSession> CreateNewPadelSessionAsync(PadelSession padel)
        {
            await _collection.InsertOneAsync(padel);
            return padel;
        }

        public async Task UpdatePadelSessionAsync(PadelSession padel)
        {
            var filter = Builders<PadelSession>.Filter.Eq(x => x.Id, padel.Id);
            await _collection.ReplaceOneAsync(filter, padel);
            return;
        }

        public async Task DeletePadelSessionAsync(Guid id)
        {
            var filter = Builders<PadelSession>.Filter.Eq(x => x.Id, id);
            var result = await _collection.DeleteOneAsync(filter);
            return;
        }
    }
}
