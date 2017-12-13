using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSpacerFinal.Data;
using FSpacerFinal.Models;

namespace FSpacerFinal.Controllers
{
    public class DriveCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriveCardsController(ApplicationDbContext context)
        {
            _context = context;
        }
            
        // GET: DriveCards    
        public async Task<IActionResult> Index()
        {
            return View(await _context.DriveCards.ToListAsync());
        }

        // GET: DriveCards/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driveCard = await _context.DriveCards
                .SingleOrDefaultAsync(m => m.DriveNumber == id);
            if (driveCard == null)
            {
                return NotFound();
            }       

            return View(driveCard);
        }

        // GET: DriveCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DriveCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,Ratio,DriveNumber,GearNumber")] DriveCard driveCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driveCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driveCard);
        }

        // GET: DriveCards/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driveCard = await _context.DriveCards.SingleOrDefaultAsync(m => m.DriveNumber == id);
            if (driveCard == null)
            {
                return NotFound();
            }
            return View(driveCard);
        }

        // POST: DriveCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Model,Ratio,DriveNumber,GearNumber")] DriveCard driveCard)
        {
            if (id != driveCard.DriveNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driveCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriveCardExists(driveCard.DriveNumber))
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
            return View(driveCard);
        }

        // GET: DriveCards/Delete/5    
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var driveCard = await _context.DriveCards
                .SingleOrDefaultAsync(m => m.DriveNumber == id);
            if (driveCard == null)
            {
                return NotFound();
            }

            return View(driveCard);
        }

        // POST: DriveCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        { 
            var driveCard = await _context.DriveCards.SingleOrDefaultAsync(m => m.DriveNumber == id);
            _context.DriveCards.Remove(driveCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool DriveCardExists(string id)
        {
            return _context.DriveCards.Any(e => e.DriveNumber == id);
        }
    }
}