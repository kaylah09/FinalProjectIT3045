using FinalProjectIT3045.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectIT3045.Models;


namespace FinalProjectIT3045.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteBookController : ControllerBase
    {
        private readonly FinalProjectTeammatesContext _context;
        public FavoriteBookController(FinalProjectTeammatesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteBook>>> GetFavoriteBook([FromQuery] int? id)
        {
            // if an id is not provided, return the first 5 favorite books

            if (id == 0 || id == null)
            {
                var favoriteBooks = await _context.FavoriteBooks
                .Take(5)
                .ToListAsync();

                return Ok(favoriteBooks);
            }

            var favoriteBook = await _context.FavoriteBooks.FindAsync(id);
            // if the favorite book with the provided id is not found, return a 404 Not Found response

            if (favoriteBook == null)
            {
                return NotFound();
            }
            // otherwise, return the favorite book with the provided id
            return Ok(favoriteBook);
        }


        [HttpPost]
        public async Task<ActionResult<FavoriteBook>> CreateFavoriteBook([FromBody] FavoriteBook favoriteBook)
        {
            _context.FavoriteBooks.Add(favoriteBook);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFavoriteBook), new { id = favoriteBook.Id }, favoriteBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavoriteBook(int id, [FromBody] FavoriteBook favoriteBook)
        {
            if (id != favoriteBook.Id)
            {
                return BadRequest();
            }
            _context.Entry(favoriteBook).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteBookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool FavoriteBookExists(int id)
        {
            return _context.FavoriteBooks.Any(e => e.Id == id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteBook(int id) {
            var favoriteBook = await _context.FavoriteBooks.FindAsync(id);
            if (favoriteBook == null)
            {
                return NotFound();
            }
            _context.FavoriteBooks.Remove(favoriteBook);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}

       