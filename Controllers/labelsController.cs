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
    public class labelsController : ApplicationBasedController
    {
        private readonly ApplicationDbContext _context;

        public labelsController(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        // GET: labels
        [Authorize(Roles = RoleName.admin)]

        public async Task<IActionResult> Index()
        {
            return View(await _context.label.ToListAsync());
        }

        // GET: labels/Details/5
        [AllowAnonymous]
        [HttpGet("Labels/{name}")]
        public async Task<IActionResult> Details(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var label = await _context.label
                .Include(m => m.BlogLabels)
                .ThenInclude(m => m.Blog)
                .FirstOrDefaultAsync(m => m.Name == name);


            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // GET: labels/Create
        [HttpGet("Labels/Create")]
        [Authorize(Roles = RoleName.admin)]

        public IActionResult Create()
        {
            return View();
        }

        // POST: labels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.admin)]

        public async Task<IActionResult> Create([Bind("Id,Name,Description")] label label)
        {
            if (ModelState.IsValid)
            {
                _context.Add(label);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(label);
        }

        // GET: labels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var label = await _context.label.FindAsync(id);
            if (label == null)
            {
                return NotFound();
            }
            return View(label);
        }

        // POST: labels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.admin)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] label label)
        {
            if (id != label.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(label);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!labelExists(label.Id))
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
            return View(label);
        }

        // GET: labels/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var label = await _context.label
                .FirstOrDefaultAsync(m => m.Id == id);
            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // POST: labels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var label = await _context.label.FindAsync(id);
            _context.label.Remove(label);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool labelExists(int id)
        {
            return _context.label.Any(e => e.Id == id);
        }
    }
}
