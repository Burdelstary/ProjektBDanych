using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektBDanych.Data;
using ProjektBDanych.Models;

namespace ProjektBDanych.Controllers
{
    [Authorize]
    public class DzienniksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DzienniksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dzienniks
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["GradeSortParam"] = String.IsNullOrEmpty(sortOrder) ? "grade_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewData["NameSortParam"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";


            var records = from r in _context.Dziennik
                          select r;

            switch (sortOrder)
            {
                case "grade_desc":
                    records = records.OrderByDescending(r => r.Grade);
                    break;
                case "date_asc":
                    records = records.OrderBy(r => r.GradeDate);
                    break;
                case "date_desc":
                    records = records.OrderByDescending(r => r.GradeDate);
                    break;
                case "name_asc":
                    records = records.OrderBy(r => r.Surname).ThenBy(r => r.FirstName);
                    break;
                case "name_desc":
                    records = records.OrderByDescending(r => r.Surname).ThenByDescending(r => r.FirstName);
                    break;
                default:
                    records = records.OrderBy(r => r.Grade);
                    break;
            }

            return View(await records.AsNoTracking().ToListAsync());
        }


        // GET: Dzienniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dziennik = await _context.Dziennik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dziennik == null)
            {
                return NotFound();
            }

            return View(dziennik);
        }

        // GET: Dzienniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dzienniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,Surname,Grade,GradeDate,Subject,ClassName,SchoolYear")] Dziennik dziennik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dziennik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dziennik);
        }

        // GET: Dzienniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dziennik = await _context.Dziennik.FindAsync(id);
            if (dziennik == null)
            {
                return NotFound();
            }
            return View(dziennik);
        }

        // POST: Dzienniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,Surname,Grade,GradeDate,Subject,ClassName,SchoolYear")] Dziennik dziennik)
        {
            if (id != dziennik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dziennik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DziennikExists(dziennik.ID))
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
            return View(dziennik);
        }

        // GET: Dzienniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dziennik = await _context.Dziennik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dziennik == null)
            {
                return NotFound();
            }

            return View(dziennik);
        }

        // POST: Dzienniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dziennik = await _context.Dziennik.FindAsync(id);
            if (dziennik != null)
            {
                _context.Dziennik.Remove(dziennik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
        private bool DziennikExists(int id)
        {
            return _context.Dziennik.Any(e => e.ID == id);
        }
    }
}
