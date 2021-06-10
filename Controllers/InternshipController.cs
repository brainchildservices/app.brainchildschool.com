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

namespace SimpleApp
{
    public class InternshipController : Controller
    {
        private readonly ILogger<InternshipController> _logger;
        private readonly CanditateDbContext _context;
        
        private readonly IConfiguration _configuration;


        public InternshipController(CanditateDbContext context, IConfiguration configuration,ILogger<InternshipController> logger)
        {
            _context = context;
            _configuration=configuration;
            _logger=logger;
        }

        
        // GET: CandidateDetails/Apply
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply([Bind("CandidateID,EmailID,MobileNo,TypeId,Shedule,Attendance,Message")] CandidateDetails candidateDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(candidateDetails);
                    candidateDetails.Message="InternshipProgramme";
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

        
    }
}
