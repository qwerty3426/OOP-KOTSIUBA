using System.Text.Json;
using lab28v5.Models;

namespace lab28v5.Repositories
{
    public class SongRepository
    {
        private List<Song> _songs = new List<Song>();
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };

        public void Add(Song song) => _songs.Add(song);
        public List<Song> GetAll() => _songs;
        public Song? GetById(int id) => _songs.FirstOrDefault(s => s.Id == id);

        public async Task SaveToFileAsync(string filename)
        {
            using FileStream fs = File.Create(filename);
            await JsonSerializer.SerializeAsync(fs, _songs, _options);
        }

        public async Task LoadFromFileAsync(string filename)
        {
            if (!File.Exists(filename)) return;
            using FileStream fs = File.OpenRead(filename);
            _songs = await JsonSerializer.DeserializeAsync<List<Song>>(fs, _options) ?? new List<Song>();
        }
    }
}