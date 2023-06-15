using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HandyMan_Techlift.Data;
using HandyMan_Techlift.Models;
using HandyMan_Techlift.Repositories;

namespace HandyMan_Techlift.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HandyManDbContext _context;
        private readonly ICategoriesrep _rep;

        public CategoriesController(HandyManDbContext context,ICategoriesrep rep)
        {
            _context = context;
            _rep = rep;

        }

        public IActionResult Create()
        {
            ViewBag.cat = _context.categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories cat)
        {
            //memory stream is .net class/// file byte array convert

            MemoryStream stream = new MemoryStream();
            

            cat.CategoryPicture.CopyTo(stream);

            //ms to byte array

            cat.CategoryImage = stream.ToArray();
            _rep.Create(cat);
            //_context.doctorInfo.Add(inf);
            //_context.SaveChanges();

            ViewBag.cat = _context.categories.ToList();
            return RedirectToAction ("Index");


        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return _context.categories != null ?
                        View(await _context.categories.ToListAsync()) :
                        Problem("Entity set 'HandyManDbContext.categories'  is null.");
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var categories = await _context.categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        //// GET: Categories/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Categories/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryImage")] Categories inf,Categories categories)
        //{
        //    MemoryStream stream = new MemoryStream();

        //    //file data carry
        //    inf.CategoryPicture.CopyTo(stream);

        //    //ms to byte array

        //    inf.CategoryImage = stream.ToArray();

        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(categories);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(categories);
        //}


        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var categories = await _context.categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("CategoryId,CategoryName,CategoryImage")] Categories categories)
        {
            if (id != categories.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.CategoryId))
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
            return View(categories);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var categories = await _context.categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.categories == null)
            {
                return Problem("Entity set 'HandyManDbContext.categories'  is null.");
            }
            var categories = await _context.categories.FindAsync(id);
            if (categories != null)
            {
                _context.categories.Remove(categories);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriesExists(Guid? id)
        {
            return (_context.categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
