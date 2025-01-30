using MongoDB.Driver;
using NotesAppAPI.Models;

namespace NotesAppAPI.Services
{
    public class NotesService
    {
        private readonly IMongoCollection<Note> _notesCollection;

        public NotesService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("NotesAppDB");
            _notesCollection = database.GetCollection<Note>("Notes");
        }

        public async Task<List<Note>> GetAsync() =>
            await _notesCollection.Find(_ => true).ToListAsync();

    }
}
