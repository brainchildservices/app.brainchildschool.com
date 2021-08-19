using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleApp.Dbcontext;
using SimpleApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
namespace SimpleApp
{
   [Authorize]
    public class CandidateDetailsController : Controller
    {
        private readonly ILogger<CandidateDetailsController> _logger;
        private readonly CanditateDbContext _context;
        
        private readonly IConfiguration _configuration;


        public CandidateDetailsController(CanditateDbContext context, IConfiguration configuration,ILogger<CandidateDetailsController> logger)
        {
            _context = context;
            _configuration=configuration;
            _logger=logger;
        }

        // GET: CandidateDetails
        
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("The candidate index page has been accessed");                  
                var canditateDbContext = _context.CandidateDetails.Include(c => c.EducationLevel);
                return View(await canditateDbContext.ToListAsync());
                
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
            
        }

        // GET: CandidateDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                _logger.LogInformation("The candidate details page has been accessed");    
                if (id == null)
                {
                    return NotFound();
                }

                var candidateDetails = await _context.CandidateDetails
                    .Include(c => c.EducationLevel)
                    .FirstOrDefaultAsync(m => m.CandidateID == id);
                if (candidateDetails == null)
                {
                    return NotFound();
                }

                return View(candidateDetails);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // GET: CandidateDetails/Apply
        [AllowAnonymous]
        public IActionResult Apply()
        {
            try
            {
                _logger.LogInformation("The candidate apply page has been accessed");   
                ViewData["TypeId"] = new SelectList(_context.EducationLevel, "TypeId", "EducationType");
                return View();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // POST: CandidateDetails/Apply
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply([Bind("CandidateID,EmailID,MobileNo,TypeId,Shedule,Attendance,Message")] CandidateDetails candidateDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(candidateDetails);
                    await _context.SaveChangesAsync();
                    return RedirectToRoute("success");
                }
                ViewData["TypeId"] = new SelectList(_context.EducationLevel, "TypeId", "EducationType", candidateDetails.TypeId);
                return View(candidateDetails);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact([Bind("Name,MobileNo,EmailID")] QuickCandidateForm candidateForm)
        {
            try
            {
           
                CandidateDetails candidateDetails = new CandidateDetails(){
                    EmailID=candidateForm.EmailID,
                    MobileNo=candidateForm.MobileNo,
                    Message=candidateForm.Name,
                    TypeId=1,
                    Attendance="QuickContactForm"
                };
                _context.Add(candidateDetails);
                await _context.SaveChangesAsync();
                return RedirectToRoute("success");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // GET: CandidateDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try{
                if (id == null)
                {
                    return NotFound();
                }
    
                var candidateDetails = await _context.CandidateDetails.FindAsync(id);
                if (candidateDetails == null)
                {
                    return NotFound();
                }
                ViewData["TypeId"] = new SelectList(_context.EducationLevel, "TypeId", "EducationType", candidateDetails.TypeId);
                return View(candidateDetails);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // POST: CandidateDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidateID,EmailID,MobileNo,TypeId,Shedule,Attendance,Message")] CandidateDetails candidateDetails)
        {
            try
            {
                if (id != candidateDetails.CandidateID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(candidateDetails);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CandidateDetailsExists(candidateDetails.CandidateID))
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
                ViewData["TypeId"] = new SelectList(_context.EducationLevel, "TypeId", "EducationType", candidateDetails.TypeId);
                return View(candidateDetails);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // GET: CandidateDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateDetails = await _context.CandidateDetails
                .Include(c => c.EducationLevel)
                .FirstOrDefaultAsync(m => m.CandidateID == id);
            if (candidateDetails == null)
            {
                return NotFound();
            }

            return View(candidateDetails);
        }

        // POST: CandidateDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidateDetails = await _context.CandidateDetails.FindAsync(id);
            _context.CandidateDetails.Remove(candidateDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Success()
        {
            return View();
        }

        private bool CandidateDetailsExists(int id)
        {
            return _context.CandidateDetails.Any(e => e.CandidateID == id);
        }
    }
}
