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
using HandyMan_Techlift.Models.VMs;

namespace HandyMan_Techlift.Controllers
{
    public class ServicesController : Controller
    {
        private readonly HandyManDbContext _context;
        private readonly IServicesrep _rep;

        public ServicesController(HandyManDbContext context, IServicesrep rep)
        {
            _context = context;
            _rep = rep;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
              return _context.services != null ? 
                          View(await _context.services.ToListAsync()) :
                          Problem("Entity set 'HandyManDbContext.services'  is null.");
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.services == null)
            {
                return NotFound();
            }

            var services = await _context.services
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }
        public IActionResult Create()
        {
            ViewBag.serve = _context.services.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Services serve )
        {
            //memory stream is .net class/// file byte array convert

            MemoryStream stream = new MemoryStream();


            serve.ServicePicture.CopyTo(stream);

            //ms to byte array

            serve.ServiceImage = stream.ToArray();
            _rep.Create(serve);
            //_context.doctorInfo.Add(inf);
            //_context.SaveChanges();

            ViewBag.serve = _context.services.ToList();
            return RedirectToAction("Index");


        }
        // GET: Services/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Services/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ServiceID,ServiceName,ServiceDescription,ServicePrice,ServiceImage")] Services services)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(services);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(services);
        //}

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.services == null)
            {
                return NotFound();
            }

            var services = await _context.services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("ServiceID,ServiceName,ServiceDescription,ServicePrice,ServiceImage")] Services services)
        {
            if (id != services.ServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(services);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesExists(services.ServiceID))
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
            return View(services);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.services == null)
            {
                return NotFound();
            }

            var services = await _context.services
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.services == null)
            {
                return Problem("Entity set 'HandyManDbContext.services'  is null.");
            }
            var services = await _context.services.FindAsync(id);
            if (services != null)
            {
                _context.services.Remove(services);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult _ListAll()
        {

            return View(_context.tblservice.ToList());
        }

        public IActionResult AddToCart(Guid serviceId)
        {
            _context.tblOrders.Add(new Models.Orders { ServiceId = serviceId });
            _context.SaveChanges();
            return RedirectToAction("_ListAll");
        }

        public IActionResult ShowCart()
        {
            var res = (from c in _context.tblOrders
                       join k in _context.tblservice
                       on c.ServiceId equals k.ServiceID
                       select new OrderVM
                       {
                           serviceName = k.ServiceName,
                           servicePrice = k.ServicePrice,


                       }
                       ).ToList();

            return PartialView("_Cart", res);

        }
        private bool ServicesExists(Guid? id)
        {
          return (_context.services?.Any(e => e.ServiceID == id)).GetValueOrDefault();
        }
    }
}
