using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class CatergoriesController : ApplicationBasedController
    {
        private readonly ApplicationDbContext _context;

        public CatergoriesController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: Catergories
        [Authorize(Roles = RoleName.admin)]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catergory.ToListAsync());
        }

        // GET: Catergories/Details/name 
        [HttpGet("Catergories/details/{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var catergory = await _context.Catergory
                .Include(c => c.Blogs)
                .FirstOrDefaultAsync(m => m.Name == name);
            if (catergory == null)
            {
                return NotFound();
            }

            return View(catergory);
        }

        // GET: Catergories/Create
        [Authorize(Roles = RoleName.admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catergories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.admin)]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Catergory catergory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catergory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catergory);
        }

        // GET: Catergories/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catergory = await _context.Catergory.FindAsync(id);
            if (catergory == null)
            {
                return NotFound();
            }
            return View(catergory);
        }

        // POST: Catergories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.admin)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Catergory catergory)
        {
            if (id != catergory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catergory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatergoryExists(catergory.Id))
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
            return View(catergory);
        }

        // GET: Catergories/Delete/5
        [Authorize(Roles = RoleName.admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catergory = await _context.Catergory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catergory == null)
            {
                return NotFound();
            }

            return View(catergory);
        }

        // POST: Catergories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catergory = await _context.Catergory.FindAsync(id);
            _context.Catergory.Remove(catergory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatergoryExists(int id)
        {
            return _context.Catergory.Any(e => e.Id == id);
        }
    }
}
