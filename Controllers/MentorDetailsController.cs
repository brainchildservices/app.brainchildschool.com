using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleApp.Dbcontext;
using SimpleApp.Models;

namespace SimpleApp
{
    public class MentorDetailsController : Controller
    {
        private readonly CanditateDbContext _context;

        public MentorDetailsController(CanditateDbContext context)
        {
            _context = context;
        }

        // GET: MentorDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.MentorDetails.ToListAsync());
        }

        // GET: MentorDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorDetails = await _context.MentorDetails
                .FirstOrDefaultAsync(m => m.MentorID == id);
            if (mentorDetails == null)
            {
                return NotFound();
            }

            return View(mentorDetails);
        }

        // GET: MentorDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MentorDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MentorID,EmailID,MobileNo,Qualification,Attendance,Resume")] MentorDetails mentorDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mentorDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mentorDetails);
        }

        // GET: MentorDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorDetails = await _context.MentorDetails.FindAsync(id);
            if (mentorDetails == null)
            {
                return NotFound();
            }
            return View(mentorDetails);
        }

        // POST: MentorDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MentorID,EmailID,MobileNo,Qualification,Attendance,Resume")] MentorDetails mentorDetails)
        {
            if (id != mentorDetails.MentorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentorDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorDetailsExists(mentorDetails.MentorID))
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
            return View(mentorDetails);
        }

        // GET: MentorDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentorDetails = await _context.MentorDetails
                .FirstOrDefaultAsync(m => m.MentorID == id);
            if (mentorDetails == null)
            {
                return NotFound();
            }

            return View(mentorDetails);
        }

        // POST: MentorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentorDetails = await _context.MentorDetails.FindAsync(id);
            _context.MentorDetails.Remove(mentorDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorDetailsExists(int id)
        {
            return _context.MentorDetails.Any(e => e.MentorID == id);
        }
    }
}
