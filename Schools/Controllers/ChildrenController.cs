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

        public ChildrenController(SchoolApiContext _context)
        {
            this._context = _context;
        }

        // GET: api/Children
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> GetChild()
        {
            return await _context.Child.ToListAsync();
        }

        // GET: api/Children/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Child>> GetChild(int Id)
        {
            var Child = await _context.Child.FindAsync(Id);

            if (Child == null)
            {
                return NotFound();
            }

            return Child;
        }

        // PUT: api/Children/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChild(int Id, Child Child)
        {
            if (Id != Child.Id)
            {
                return BadRequest();
            }

            _context.Entry(Child).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildExists(Id))
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
        public async Task<ActionResult<Child>> PostChild(Child Child)
        {
            _context.Child.Add(Child);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChild", new { id = Child.Id }, Child);
        }

        // DELETE: api/Children/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Child>> DeleteChild(int Id)
        {
            var Child = await _context.Child.FindAsync(Id);
            if (Child == null)
            {
                return NotFound();
            }

            _context.Child.Remove(Child);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ChildExists(int Id)
        {
            return _context.Child.Any(e => e.Id == Id);
        }
    }
}