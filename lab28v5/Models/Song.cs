namespace lab28v5.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DurationSeconds { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}