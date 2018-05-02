using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diller.Models;
using Diller.Data;

namespace Diller.Controllers
{
    [Produces("application/json")]
    [Route("api/AutoBrands")]
    public class AutoBrandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoBrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AutoBrands
        [HttpGet]
        public IEnumerable<AutoBrand> GetAutoBrand()
        {
            return _context.AutoBrand;
        }

        // GET: api/AutoBrands/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutoBrand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autoBrand = await _context.AutoBrand.SingleOrDefaultAsync(m => m.Id == id);

            if (autoBrand == null)
            {
                return NotFound();
            }

            return Ok(autoBrand);
        }

        // PUT: api/AutoBrands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutoBrand([FromRoute] int id, [FromBody] AutoBrand autoBrand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autoBrand.Id)
            {
                return BadRequest();
            }

            _context.Entry(autoBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoBrandExists(id))
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

        // POST: api/AutoBrands
        [HttpPost]
        public async Task<IActionResult> PostAutoBrand([FromBody] AutoBrand autoBrand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AutoBrand.Add(autoBrand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutoBrand", new { id = autoBrand.Id }, autoBrand);
        }

        // DELETE: api/AutoBrands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutoBrand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autoBrand = await _context.AutoBrand.SingleOrDefaultAsync(m => m.Id == id);
            if (autoBrand == null)
            {
                return NotFound();
            }

            _context.AutoBrand.Remove(autoBrand);
            await _context.SaveChangesAsync();

            return Ok(autoBrand);
        }

        private bool AutoBrandExists(int id)
        {
            return _context.AutoBrand.Any(e => e.Id == id);
        }
    }
}