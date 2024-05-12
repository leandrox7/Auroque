using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Auroque.Domain.Entities;
using Microsoft.AspNetCore.Cors;

namespace Auroque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]

    public class CattleBreedsController : ControllerBase
    {
        private readonly AuroqueContext _context;

        public CattleBreedsController(AuroqueContext context)
        {
            _context = context;
        }

        // GET: api/CattleBreeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CattleBreed>>> GetCattleBreeds()
        {
          if (_context.CattleBreeds == null)
          {
              return NotFound();
          }
            return await _context.CattleBreeds.ToListAsync();
        }

        // GET: api/CattleBreeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CattleBreed>> GetCattleBreed(int id)
        {
          if (_context.CattleBreeds == null)
          {
              return NotFound();
          }
            var cattleBreed = await _context.CattleBreeds.FindAsync(id);

            if (cattleBreed == null)
            {
                return NotFound();
            }

            return cattleBreed;
        }

        // PUT: api/CattleBreeds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCattleBreed(int id, CattleBreed cattleBreed)
        {
            if (id != cattleBreed.Id)
            {
                return BadRequest();
            }

            _context.Entry(cattleBreed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CattleBreedExists(id))
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

        // POST: api/CattleBreeds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CattleBreed>> PostCattleBreed(CattleBreed cattleBreed)
        {
          if (_context.CattleBreeds == null)
          {
              return Problem("Entity set 'AuroqueContext.CattleBreeds'  is null.");
          }
            _context.CattleBreeds.Add(cattleBreed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCattleBreed", new { id = cattleBreed.Id }, cattleBreed);
        }

        // DELETE: api/CattleBreeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCattleBreed(int id)
        {
            if (_context.CattleBreeds == null)
            {
                return NotFound();
            }
            var cattleBreed = await _context.CattleBreeds.FindAsync(id);
            if (cattleBreed == null)
            {
                return NotFound();
            }

            _context.CattleBreeds.Remove(cattleBreed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CattleBreedExists(int id)
        {
            return (_context.CattleBreeds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
