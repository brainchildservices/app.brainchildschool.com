using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleApp.Dbcontext;
using SimpleApp.Models;
using SimpleApp;    

namespace SimpleApp
{
    public class BussinessDetailsController : Controller
    {
        private readonly CanditateDbContext _context;

        public BussinessDetailsController(CanditateDbContext context)
        {
            _context = context;
        }

        // GET: BussinessDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.BussinessDetails.ToListAsync());
        }

        // GET: BussinessDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bussinessDetails = await _context.BussinessDetails
                .FirstOrDefaultAsync(m => m.BussinessID == id);
            if (bussinessDetails == null)
            {
                return NotFound();
            }

            return View(bussinessDetails);
        }

        // GET: BussinessDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BussinessDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BussinessID,EmailID,MobileNo,Subject,Message")] BussinessDetails bussinessDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bussinessDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction("Success");
            }
            return View(bussinessDetails);
        }

        // GET: BussinessDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bussinessDetails = await _context.BussinessDetails.FindAsync(id);
            if (bussinessDetails == null)
            {
                return NotFound();
            }
            return View(bussinessDetails);
        }

        // POST: BussinessDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BussinessID,EmailID,MobileNo,Subject,Message")] BussinessDetails bussinessDetails)
        {
            if (id != bussinessDetails.BussinessID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bussinessDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BussinessDetailsExists(bussinessDetails.BussinessID))
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
            return View(bussinessDetails);
        }

        // GET: BussinessDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bussinessDetails = await _context.BussinessDetails
                .FirstOrDefaultAsync(m => m.BussinessID == id);
            if (bussinessDetails == null)
            {
                return NotFound();
            }

            return View(bussinessDetails);
        }

        // POST: BussinessDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bussinessDetails = await _context.BussinessDetails.FindAsync(id);
            _context.BussinessDetails.Remove(bussinessDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Success()
        {
            return View();
        }
        private bool BussinessDetailsExists(int id)
        {
            return _context.BussinessDetails.Any(e => e.BussinessID == id);
        }
    }
}
