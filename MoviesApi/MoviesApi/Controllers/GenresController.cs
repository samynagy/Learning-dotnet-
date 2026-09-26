using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public GenresController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _context.Genres.ToListAsync();
            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(GenreDto dto)
        {
            var genre = new Genre
            {
                Name = dto.Name
            };
            await _context.Genres.AddAsync(genre);
            _context.SaveChanges();

            return Ok(genre);
        }
        [HttpPut("id")]
        /// api/Genres/id
        public async Task<IActionResult> UpdateAsync(int id , [FromBody] GenreDto dto )
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(g => g.Id == id);
            if (genre == null)
            {
                return NotFound($"No genre was found with id :{id}");
            }
            genre.Name = dto.Name;
            _context.SaveChanges();

            return Ok(genre);
        }
    }
}
