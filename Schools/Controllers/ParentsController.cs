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
    public class ParentsController : ControllerBase
    {
        private readonly SchoolApiContext _context;

        public ParentsController(SchoolApiContext _context)
        {
            this._context = _context;
        }

        // GET: api/Parents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parent>>> GetParent()
        {
            return await _context.Parent.ToListAsync();
        }

        // PUT: api/Parents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParent(int Id, Parent Parent)
        {
            if (Id != Parent.Id)
            {
                return BadRequest();
            }

            _context.Entry(Parent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentExists(Id))
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

        // POST: api/Parents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Parent>> PostParent(Parent Parent)
        {
            _context.Parent.Add(Parent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParent", new { id = Parent.Id }, Parent);
        }

        // DELETE: api/Parents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parent>> DeleteParent(int id)
        {
            var parent = await _context.Parent.FindAsync(id);
            if (parent == null)
            {
                return NotFound();
            }

            _context.Parent.Remove(parent);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ParentExists(int id)
        {
            return _context.Parent.Any(e => e.Id == id);
        }
    }
}
