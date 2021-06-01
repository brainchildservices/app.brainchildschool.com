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
using Microsoft.Extensions.Logging;

namespace SimpleApp
{
    public class BussinessDetailsController : Controller
    {
        private readonly ILogger<BussinessDetailsController> _logger;
        private readonly CanditateDbContext _context;

        public BussinessDetailsController(CanditateDbContext context,ILogger<BussinessDetailsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: BussinessDetails
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("The business index page has been accessed"); 
                return View(await _context.BussinessDetails.ToListAsync());
             }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
            
        }

        // GET: BussinessDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
             try
            {
                _logger.LogInformation("The business details page has been accessed"); 

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
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // GET: BussinessDetails/Create
        public IActionResult Create()
        {
             try
            {
                _logger.LogInformation("The business create page has been accessed"); 
                return View();
             }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // POST: BussinessDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact([Bind("EmailID,MobileNo,Subject,Message")] BussinessDetails bussinessDetails)
        {          
             try
            {
                _logger.LogInformation("The business contact page has been accessed");  
                bussinessDetails.Message="QuickContact";
                _context.Add(bussinessDetails);
                await _context.SaveChangesAsync();
                return RedirectToRoute("success");
             }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        

        // GET: BussinessDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
             try
            {
                _logger.LogInformation("The business edit page has been accessed"); 
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // POST: BussinessDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BussinessID,EmailID,MobileNo,Subject,Message")] BussinessDetails bussinessDetails)
        {
             try
            {
                _logger.LogInformation("The business edit post page has been accessed"); 
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // GET: BussinessDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
             try
            {
                _logger.LogInformation("The business delete page has been accessed"); 
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }

        // POST: BussinessDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             try
            {
                _logger.LogInformation("The business deleteconfirmed page has been accessed"); 
            var bussinessDetails = await _context.BussinessDetails.FindAsync(id);
            _context.BussinessDetails.Remove(bussinessDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
             }
            catch (System.Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
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
