using FinalProjectIT3045.Data;
using FinalProjectIT3045.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectIT3045.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly FinalProjectTeammatesContext _context;
        public TeamMembersController(FinalProjectTeammatesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMember([FromQuery] int? id)
        {
            if (id == null || id == 0)
            {
                var teamMembers = await _context.TeamMembers
                    .Take(5)
                    .ToListAsync();

                return Ok(teamMembers);
            }

            var teamMember = await _context.TeamMembers.FindAsync(id);

            if (teamMember == null)
            {
                return NotFound();
            }

            return Ok(teamMember);
        }

        [HttpPost]
        public async Task<ActionResult<TeamMember>> CreateTeamMember([FromBody] TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeamMember), new { id = teamMember.Id }, teamMember);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeamMember( [FromBody] TeamMember teamMember)
        {
            var existingTeamMember = await _context.TeamMembers.FindAsync(teamMember.Id);


            if (existingTeamMember == null)
            {  return NotFound(); }

            _context.Entry(existingTeamMember).CurrentValues.SetValues(teamMember);

           
  
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(existingTeamMember.Id))
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

        private bool TeamMemberExists(int id)
        {
            return _context.TeamMembers.Any(e => e.Id == id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}

       

