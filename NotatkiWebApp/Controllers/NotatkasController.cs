using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotatkiWebApp.Data;
using NotatkiWebApp.Models;

namespace NotatkiWebApp.Controllers
{
    public class NotatkasController : Controller
    {
        private readonly AppDbContext _context;

        public NotatkasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Notatkas
        public async Task<IActionResult> Index(

        string searchString,
        List<string> categoryFilter,
        string sortOrder,
        string favoriteOnly,
        DateTime? dateFilter,
        DateTime? fromDate,
        DateTime? toDate)
        {
            var notatki = from n in _context.Notatkas select n;

            // Filtrowanie po wyszukiwarce
            if (!string.IsNullOrEmpty(searchString))
            {
                var lowerSearch = searchString.ToLower();
                notatki = notatki.Where(n =>
                    n.Tytul.ToLower().Contains(lowerSearch) ||
                    n.Tresc.ToLower().Contains(lowerSearch));
            }

            // Filtrowanie po kategoriach (jeśli nie pusto)
            if (categoryFilter != null && categoryFilter.Any())
            {
                notatki = notatki.Where(n => categoryFilter.Contains(n.Kategoria.ToString()));
            }

            // Filtrowanie po dacie
            if (dateFilter.HasValue)
            {
                notatki = notatki.Where(n => n.DataUtworzenia.Date == dateFilter.Value.Date);
            }

            if (fromDate.HasValue)
            {
                notatki = notatki.Where(n => n.DataUtworzenia.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                notatki = notatki.Where(n => n.DataUtworzenia.Date <= toDate.Value.Date);
            }

            //Filtrowanie po ulubionych
            if (!string.IsNullOrEmpty(favoriteOnly) && favoriteOnly == "true")
            {
                notatki = notatki.Where(n => n.Ulubiona);
            }

            // Sortowanie
            ViewData["CurrentSort"] = sortOrder;
            notatki = sortOrder switch
            {
                "title_desc" => notatki.OrderByDescending(n => n.Tytul),
                "Date" => notatki.OrderBy(n => n.DataUtworzenia),
                "date_desc" => notatki.OrderByDescending(n => n.DataUtworzenia),
                _ => notatki.OrderBy(n => n.Tytul)
            };

            return View(await notatki.ToListAsync());
        }

        // GET: Notatkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notatka = await _context.Notatkas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notatka == null)
            {
                return NotFound();
            }

            return View(notatka);
        }

        // GET: Notatkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notatkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tytul,Tresc,Kategoria")] Notatka notatka)
        {
            if (ModelState.IsValid)
            {
                notatka.DataUtworzenia = DateTime.Now;
                _context.Add(notatka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notatka);
        }

        // GET: Notatkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notatka = await _context.Notatkas.FindAsync(id);
            if (notatka == null)
            {
                return NotFound();
            }
            return View(notatka);
        }

        // GET: Notatkas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,Tresc,Kategoria,Ulubiona")] Notatka notatka)
        {
            if (id != notatka.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existing = await _context.Notatkas.FindAsync(id);
                    if (existing == null)
                        return NotFound();

                    existing.Tytul = notatka.Tytul;
                    existing.Tresc = notatka.Tresc;
                    existing.Kategoria = notatka.Kategoria;
                    existing.Ulubiona = notatka.Ulubiona;
                    existing.DataEdycji = DateTime.Now;

                    _context.Update(existing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotatkaExists(notatka.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(notatka);
        }

        //Dodawanie ulubionych
        [HttpPost]
        public IActionResult ToggleFavorite(int id, string returnUrl = null)
        {
            var notatka = _context.Notatkas.FirstOrDefault(n => n.Id == id);
            if (notatka == null)
            {
                return NotFound();
            }

            notatka.Ulubiona = !notatka.Ulubiona;
            _context.SaveChanges();

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Notatkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notatka = await _context.Notatkas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notatka == null)
            {
                return NotFound();
            }

            return View(notatka);
        }

        // POST: Notatkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notatka = await _context.Notatkas.FindAsync(id);
            if (notatka != null)
            {
                _context.Notatkas.Remove(notatka);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotatkaExists(int id)
        {
            return _context.Notatkas.Any(e => e.Id == id);
        }
    }
}
