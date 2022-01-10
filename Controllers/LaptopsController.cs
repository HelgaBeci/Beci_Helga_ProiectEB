using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beci_Helga_Proiect.Data;
using Beci_Helga_Proiect.Models;
using Microsoft.AspNetCore.Authorization;

namespace Beci_Helga_Proiect.Controllers
{
    [Authorize(Roles = "Employee")]
    public class LaptopsController : Controller
    {
        private readonly StoreContext _context;

        public LaptopsController(StoreContext context)
        {
            _context = context;
        }

        // GET: Laptops
        [AllowAnonymous]
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ModelSortParm"] = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var laptops = from b in _context.Laptops
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                laptops = laptops.Where(s => s.Model.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "model_desc":
                    laptops = laptops.OrderByDescending(b => b.Model);
                    break;
                case "Price":
                    laptops = laptops.OrderBy(b => b.Price);
                    break;
                case "price_desc":
                    laptops = laptops.OrderByDescending(b => b.Price);
                    break;
                default:
                    laptops = laptops.OrderBy(b => b.Model);
                    break;
            }
            int pageSize = 2;
            return View(await PaginatedList<Laptop>.CreateAsync(laptops.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Laptops/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                 .Include(s => s.Orders)
                 .ThenInclude(e => e.Customer)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,Company,Price")] Laptop laptop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(laptop);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            
            }
                catch (DbUpdateException /* ex*/)
                {
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists ");
                }
            return View(laptop);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Laptops.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Laptop>(
            studentToUpdate,
            "",
            s => s.Company, s => s.Model, s => s.Price))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists");
                }
            }
            return View(studentToUpdate);
        }
        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (laptop == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                "Delete failed. Try again";
            }
            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Laptops.Remove(laptop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptops.Any(e => e.ID == id);
        }
    }
}
