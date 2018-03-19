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
    [Route("api/Managers")]
    public class ManagersController : Controller
    {
        private readonly DillerContext _context;

        public ManagersController(DillerContext context)
        {
            _context = context;
        }

        // GET: api/Managers
        [HttpGet]
        public IEnumerable<Manager> GetManager()
        {
            return _context.Manager;
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManager([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manager = await _context.Manager.SingleOrDefaultAsync(m => m.Id == id);

            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }

        // PUT: api/Managers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager([FromRoute] int id, [FromBody] Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manager.Id)
            {
                return BadRequest();
            }

            _context.Entry(manager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(id))
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

        // POST: api/Managers
        [HttpPost]
        public async Task<IActionResult> PostManager([FromBody] Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Manager.Add(manager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManager", new { id = manager.Id }, manager);
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manager = await _context.Manager.SingleOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }

            _context.Manager.Remove(manager);
            await _context.SaveChangesAsync();

            return Ok(manager);
        }

        private bool ManagerExists(int id)
        {
            return _context.Manager.Any(e => e.Id == id);
        }
    }
}