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
    [Route("api/AutoCategories")]
    public class AutoCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AutoCategories
        [HttpGet]
        public IEnumerable<AutoCategory> GetAutoCategory()
        {
            return _context.AutoCategories;
        }

        // GET: api/AutoCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutoCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autoCategory = await _context.AutoCategories.SingleOrDefaultAsync(m => m.Id == id);

            if (autoCategory == null)
            {
                return NotFound();
            }

            return Ok(autoCategory);
        }

        // PUT: api/AutoCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutoCategory([FromRoute] int id, [FromBody] AutoCategory autoCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autoCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(autoCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoCategoryExists(id))
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

        // POST: api/AutoCategories
        [HttpPost]
        public async Task<IActionResult> PostAutoCategory([FromBody] AutoCategory autoCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AutoCategories.Add(autoCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutoCategory", new { id = autoCategory.Id }, autoCategory);
        }
        
        // DELETE: api/AutoCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutoCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autoCategory = await _context.AutoCategories.SingleOrDefaultAsync(m => m.Id == id);
            if (autoCategory == null)
            {
                return NotFound();
            }

            _context.AutoCategories.Remove(autoCategory);
            await _context.SaveChangesAsync();

            return Ok(autoCategory);
        }

        private bool AutoCategoryExists(int id)
        {
            return _context.AutoCategories.Any(e => e.Id == id);
        }
    }
}