using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectIT3045.Models;
using FinalProjectIT3045.Data;

[Route("api/[controller]")]
[ApiController]
public class CollegeCoursesController : ControllerBase
{
    private readonly FinalProjectTeammatesContext _context;
    public CollegeCoursesController(FinalProjectTeammatesContext context)
    {
        _context = context;
    }

    // GET: api/collegecourses/5
    [HttpGet("{id?}")]
    public async Task<ActionResult> GetCollegeCourse(int? id)
    {
        if (id != null && id != 0)
        {
            var collegeCourse = await _context.CollegeCourses.FindAsync(id);

            if (collegeCourse == null)
            {
                return NotFound();
            }

            return Ok(collegeCourse);
        } else
        {
            var collegeCourses = await _context.CollegeCourses.Take(5).ToListAsync();

            return Ok(collegeCourses);
        }
    }

    // PUT: api/collegecourses/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCollegeCourse(int id, CollegeCourse collegecourse)
    {
        if (id != collegecourse.Id)
        {
            return BadRequest();
        }

        _context.Entry(collegecourse).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CollegeCourseExists(id))
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

    // POST: api/collegecourses
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CollegeCourse>> PostCollegeCourse(CollegeCourse collegecourse)
    {
        _context.CollegeCourses.Add(collegecourse);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCollegeCourse), new { id = collegecourse.Id }, collegecourse);
    }

    // DELETE: api/collegecourses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCollegeCourse(int id)
    {
        var collegeCourse = await _context.CollegeCourses.FindAsync(id);
        if (collegeCourse == null)
        {
            return NotFound();
        }

        _context.CollegeCourses.Remove(collegeCourse);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CollegeCourseExists(int id)
    {
        return _context.CollegeCourses.Any(e => e.Id == id);
    }
}
