using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diller.Models;

namespace Diller.Controllers
{
    public class AutoBrandsController : Controller
    {
        private readonly DillerContext _context;

        public AutoBrandsController(DillerContext context)
        {
            _context = context;
        }

        // GET: AutoBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutoBrand.ToListAsync());
        }

        // GET: AutoBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoBrand = await _context.AutoBrand
                .SingleOrDefaultAsync(m => m.Id == id);
            if (autoBrand == null)
            {
                return NotFound();
            }

            return View(autoBrand);
        }

        // GET: AutoBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutoBrands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] AutoBrand autoBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoBrand);
        }

        // GET: AutoBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoBrand = await _context.AutoBrand.SingleOrDefaultAsync(m => m.Id == id);
            if (autoBrand == null)
            {
                return NotFound();
            }
            return View(autoBrand);
        }

        // POST: AutoBrands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] AutoBrand autoBrand)
        {
            if (id != autoBrand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoBrandExists(autoBrand.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autoBrand);
        }

        // GET: AutoBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoBrand = await _context.AutoBrand
                .SingleOrDefaultAsync(m => m.Id == id);
            if (autoBrand == null)
            {
                return NotFound();
            }

            return View(autoBrand);
        }

        // POST: AutoBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoBrand = await _context.AutoBrand.SingleOrDefaultAsync(m => m.Id == id);
            _context.AutoBrand.Remove(autoBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoBrandExists(int id)
        {
            return _context.AutoBrand.Any(e => e.Id == id);
        }
    }
}
