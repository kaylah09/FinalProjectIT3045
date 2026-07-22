using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectIT3045.Models;
using FinalProjectIT3045.Data;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly FinalProjectTeammatesContext _context;
    public PetsController(FinalProjectTeammatesContext context)
    {
        _context = context;
    }

    // GET: api/pets/5
    [HttpGet("{id?}")]
    public async Task<ActionResult> GetPet(int? id)
    {
        if (id != null && id != 0)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        } else
        {
            var pets = await _context.Pets.Take(5).ToListAsync();

            return Ok(pets);
        }
    }

    // PUT: api/pets/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPet(int id, Pet pet)
    {
        if (id != pet.Id)
        {
            return BadRequest();
        }

        _context.Entry(pet).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PetExists(id))
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

    // POST: api/pets
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Pet>> PostPet(Pet pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
    }

    // DELETE: api/pets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
        var pet = await _context.Pets.FindAsync(id);
        if (pet == null)
        {
            return NotFound();
        }

        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PetExists(int id)
    {
        return _context.Pets.Any(e => e.Id == id);
    }
}
