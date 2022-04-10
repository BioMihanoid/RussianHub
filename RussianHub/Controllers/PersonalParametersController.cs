#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RussianHub.Data;
using RussianHub.Models;

namespace RussianHub.Controllers
{
    public class PersonalParametersController : Controller
    {
        private readonly PersonalParametersContext _context;

        public PersonalParametersController(PersonalParametersContext context)
        {
            _context = context;
        }

        // GET: PersonalParameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalParameters.ToListAsync());
        }

        // GET: PersonalParameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalParameters = await _context.PersonalParameters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalParameters == null)
            {
                return NotFound();
            }

            return View(personalParameters);
        }

        // GET: PersonalParameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalParameters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ade,Weigh,Height,Nickname,RealName,City,Gender,Info,EyeColor,HairColor,Character,DatefBirth")] PersonalParameters personalParameters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalParameters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalParameters);
        }

        // GET: PersonalParameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalParameters = await _context.PersonalParameters.FindAsync(id);
            if (personalParameters == null)
            {
                return NotFound();
            }
            return View(personalParameters);
        }

        // POST: PersonalParameters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ade,Weigh,Height,Nickname,RealName,City,Gender,Info,EyeColor,HairColor,Character,DatefBirth")] PersonalParameters personalParameters)
        {
            if (id != personalParameters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalParameters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalParametersExists(personalParameters.Id))
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
            return View(personalParameters);
        }

        // GET: PersonalParameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalParameters = await _context.PersonalParameters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalParameters == null)
            {
                return NotFound();
            }

            return View(personalParameters);
        }

        // POST: PersonalParameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalParameters = await _context.PersonalParameters.FindAsync(id);
            _context.PersonalParameters.Remove(personalParameters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalParametersExists(int id)
        {
            return _context.PersonalParameters.Any(e => e.Id == id);
        }
    }
}
