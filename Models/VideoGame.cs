// Implementation Model
namespace VideoGameAPI.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Platform { get; set; }
        // Foreign key of Developer
        public int? DeveloperId { get; set; }
        public Developer? Developer { get; set; }
        // Foreign key of Publisher
        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public VideoGameDetails? VideoGameDetails { get; set; }
        public List<Genre>? Genres { get; set; }
    }
}