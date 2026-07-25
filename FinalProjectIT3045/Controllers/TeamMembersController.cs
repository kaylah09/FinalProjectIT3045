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

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetTeamMember(int? id)
        {
            

            if (id == 0 || id == null)
            {
                var teamMembers = await _context.TeamMembers
                .Take(5)
                .ToListAsync();

                return Ok(teamMembers);
            }

            var teamMember = await _context.TeamMembers.FindAsync(id);
            // if the team member with the provided id is not found, return a 404 Not Found response

            if (teamMember == null)
            {
                return NotFound();
            }
            // otherwise, return the team member     with the provided id
            return Ok(teamMember);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeamMember([FromBody] TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeamMember), new { id = teamMember.Id }, teamMember);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeamMember(int id, [FromBody] TeamMember teamMember)
        {
            if (id != teamMember.Id)
            {
                return BadRequest();
            }
            _context.Entry(teamMember).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(id))
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

       

