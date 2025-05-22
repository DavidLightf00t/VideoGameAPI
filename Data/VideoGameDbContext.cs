using Microsoft.EntityFrameworkCore;
using VideoGameAPI;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        // Add database set which adds a table
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
    }
}