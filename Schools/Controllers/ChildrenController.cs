using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly SchoolApiContext _context;

        public ChildrenController(SchoolApiContext context)
        {
            _context = context;
        }

        // GET: api/Children
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> GetChild()
        {
            return await _context.Child.ToListAsync();
        }

        // GET: api/Children/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Child>> GetChild(int id)
        {
            var child = await _context.Child.FindAsync(id);

            if (child == null)
            {
                return NotFound();
            }

            return child;
        }

        // PUT: api/Children/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChild(int id, Child child)
        {
            if (id != child.id)
            {
                return BadRequest();
            }

            _context.Entry(child).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildExists(id))
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

        // POST: api/Children
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Child>> PostChild(Child child)
        {
            _context.Child.Add(child);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChild", new { id = child.id }, child);
        }

        // DELETE: api/Children/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Child>> DeleteChild(int id)
        {
            var child = await _context.Child.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }

            _context.Child.Remove(child);
            await _context.SaveChangesAsync();

            return child;
        }

        private bool ChildExists(int id)
        {
            return _context.Child.Any(e => e.id == id);
        }
    }
}
