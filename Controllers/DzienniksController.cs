using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dziennik.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("ID,Name,Surname,numberOfVotes,Voivodeship")] Dziennik dziennik)
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

        public async Task<IActionResult> Get()
        {
            Dziennik dziennik = new Dziennik();

            Random random = new Random();
            int num = random.Next(1, 460);

            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://api.sejm.gov.pl/sejm/term10/MP/" + num);
                var result = client.GetAsync(endpoint).Result;
                var json = await result.Content.ReadAsStringAsync();
                Console.WriteLine(json);

                dziennik = parseDziennik(json);
            }

            return View(dziennik);
        }

        private Dziennik parseDziennik(string json)
        {
            dynamic data = JObject.Parse(json);

            Dziennik dziennik = new Dziennik();
            dziennik.Name = data.firstName;
            dziennik.Surname = data.lastName;
            dziennik.numberOfVotes = (int)data.numberOfVotes;
            dziennik.Voivodeship = data.voivodeship;

            return dziennik;
        }

        // POST: Dzienniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Surname,numberOfVotes,Voivodeship")] Dziennik dziennik)
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
