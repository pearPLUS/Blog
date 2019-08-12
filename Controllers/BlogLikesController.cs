using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class BlogLikesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogLikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BlogLikes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogLike.ToListAsync());
        }

        // GET: BlogLikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogLike = await _context.BlogLike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogLike == null)
            {
                return NotFound();
            }

            return View(blogLike);
        }

        // GET: BlogLikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogLikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BlogId,UserId,Status")] BlogLike blogLike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogLike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogLike);
        }

        // GET: BlogLikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogLike = await _context.BlogLike.FindAsync(id);
            if (blogLike == null)
            {
                return NotFound();
            }
            return View(blogLike);
        }

        // POST: BlogLikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BlogId,UserId,Status")] BlogLike blogLike)
        {
            if (id != blogLike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogLike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogLikeExists(blogLike.Id))
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
            return View(blogLike);
        }

        // GET: BlogLikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogLike = await _context.BlogLike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogLike == null)
            {
                return NotFound();
            }

            return View(blogLike);
        }

        // POST: BlogLikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogLike = await _context.BlogLike.FindAsync(id);
            _context.BlogLike.Remove(blogLike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogLikeExists(int id)
        {
            return _context.BlogLike.Any(e => e.Id == id);
        }
    }
}
