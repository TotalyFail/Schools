using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolApiContext _context;
        private readonly SchoolService _schoolService;


        public SchoolsController(SchoolApiContext _context, SchoolService _schoolService)
        {
            this._context = _context;
            this._schoolService = _schoolService;
        }

        // GET: api/Schools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<School>>> GetSchool()
        {
            return await _context.School.ToListAsync();
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<string>>> GetSchoolsByParentsName(string Name)
        {
            List<string> Schools = _schoolService.GetSchoolByParentName(Name).ToList();

            if (Schools == null)
            {
                return NotFound();
            }

            return Schools;
        }


        // PUT: api/Schools/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool(int id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }

            _context.Entry(school).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/Schools
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<School>> PostSchool(School School)
        {
            _context.School.Add(School);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchool", new { id = School.Id }, School);
        }

        // DELETE: api/Schools/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<School>> DeleteSchool(int id)
        {
            var school = await _context.School.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.School.Remove(school);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool SchoolExists(int id)
        {
            return _context.School.Any(e => e.Id == id);
        }
    }
}
