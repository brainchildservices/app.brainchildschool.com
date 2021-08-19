using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleApp.Dbcontext;
using SimpleApp.Models;
using Microsoft.AspNetCore.Authorization;
namespace SimpleApp
{

    public class MentorDetailsController : Controller
    {
        private readonly ILogger<MentorDetailsController> _logger;
        private readonly CanditateDbContext _context;

        public MentorDetailsController(CanditateDbContext context , ILogger<MentorDetailsController> logger)
        {
            _context = context;
            _logger=logger;
        }

        // GET: MentorDetails
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("The mentor index page has been accessed");   
                return View(await _context.MentorDetails.ToListAsync());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // GET: MentorDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
              try
            {
                _logger.LogInformation("The mentor details page has been accessed");  
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
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
              try
            {
                _logger.LogInformation("The mentor create post page has been accessed");  
                if (ModelState.IsValid)
                {
                    _context.Add(mentorDetails);
                    await _context.SaveChangesAsync();
                    return RedirectToRoute("success");
                }
                return View(mentorDetails);
             }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // GET: MentorDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
              try
            {
                _logger.LogInformation("The mentor edit page has been accessed");  
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // POST: MentorDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MentorID,EmailID,MobileNo,Qualification,Attendance,Resume")] MentorDetails mentorDetails)
        {
              try
            {
                _logger.LogInformation("The mentor edit post page has been accessed");  

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
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // GET: MentorDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                _logger.LogInformation("The mentor delete page has been accessed");  
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
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
        public IActionResult Success()
        {
            return View();
        }
        private bool MentorDetailsExists(int id)
        {
            return _context.MentorDetails.Any(e => e.MentorID == id);
        }
    }
}
