using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using Adatok.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GazdakController : ControllerBase
    {
        private readonly APIContext _context;

        public GazdakController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Gazdak
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gazda>>> GetGazda()
        {
          if (_context.Gazda == null)
          {
              return NotFound();
          }
            return await _context.Gazda.Include(x=>x.Animal).ToListAsync();
        }

        // GET: api/Gazdak/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gazda>> GetGazda(int id)
        {
          if (_context.Gazda == null)
          {
              return NotFound();
          }
            var gazda = await _context.Gazda.Where(x=>x.Id==id).Include(x=>x.Animal).FirstOrDefaultAsync();

            if (gazda == null)
            {
                return NotFound();
            }

            return gazda;
        }

        // PUT: api/Gazdak/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGazda(int id, Gazda gazda)
        {
            if (id != gazda.Id)
            {
                return BadRequest();
            }

            _context.Entry(gazda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GazdaExists(id))
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

        // POST: api/Gazdak
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gazda>> PostGazda(Gazda gazda)
        {
          if (_context.Gazda == null)
          {
              return Problem("Entity set 'APIContext.Gazda'  is null.");
          }
            _context.Gazda.Add(gazda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGazda", new { id = gazda.Id }, gazda);
        }

        // DELETE: api/Gazdak/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGazda(int id)
        {
            if (_context.Gazda == null)
            {
                return NotFound();
            }
            var gazda = await _context.Gazda.FindAsync(id);
            if (gazda == null)
            {
                return NotFound();
            }

            _context.Gazda.Remove(gazda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GazdaExists(int id)
        {
            return (_context.Gazda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
