using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Data;

namespace VideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        // Use dependency injection to inject the database
        // VideoGameDbContext constructor
        private readonly VideoGameDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            // Use _context object to get the VideoGames table
            return Ok(await _context.VideoGames.ToListAsync());
        }

        // Get single video game with Id parameter
        [HttpGet("{id}")]
        public async  Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }
        
            return Ok(game);
        }
        
        // Add a new video game
        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        {
            if (newGame is null)
            {
                return BadRequest();
            }
        
            // Make changes to the given table
            _context.VideoGames.Add(newGame);
            // Store and save changes to database
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }
        
        // Update a video game
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
        {
            // Use _context object to get VideoGames table then find the game id from that table
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }
        
            game.Title = updatedGame.Title;
            game.Platform = updatedGame.Platform;
            game.Developer = updatedGame.Developer;
            game.Publisher = updatedGame.Publisher;
            
            // Save and update changes
            await _context.SaveChangesAsync();
        
            return NoContent();
        }
        
        // Delete a video game
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            // Use _context object to get VideoGames table and find the VideoGame with the specified id
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }
        
            // Remove the video game that was specified above
            _context.VideoGames.Remove(game);
            // Save and apply changed to the database
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}