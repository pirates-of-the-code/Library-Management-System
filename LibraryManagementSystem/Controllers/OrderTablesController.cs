using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.Controllers
{
  

    public class OrderTablesController : Controller
    {
        private readonly LibrarymanagementsystemContext _context;

        public OrderTablesController(LibrarymanagementsystemContext context)
        {
            _context = context;
        }

        // GET: OrderTables
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Index()
        {
            var librarymanagementsystemContext = _context.OrderTables.Include(o => o.SSNNavigation);
            return View(await librarymanagementsystemContext.ToListAsync());
        }

        // GET: OrderTables/Details/5

        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderTables == null)
            {
                return NotFound();
            }

            var orderTable = await _context.OrderTables
                .Include(o => o.SSNNavigation)
                .FirstOrDefaultAsync(m => m.Order_Id == id);
            if (orderTable == null)
            {
                return NotFound();
            }

            return View(orderTable);
        }

        // GET: OrderTables/Create

        [Authorize(Roles = "Admin, Employee, Employee")]
        public IActionResult Create()
        {
            ViewData["SSN"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: OrderTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Order_Id,date,status,SSN")] OrderTable orderTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SSN"] = new SelectList(_context.Users, "Id", "Id", orderTable.SSN);
            return View(orderTable);
        }

        // GET: OrderTables/Edit/5
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderTables == null)
            {
                return NotFound();
            }

            var orderTable = await _context.OrderTables.FindAsync(id);
            if (orderTable == null)
            {
                return NotFound();
            }
            ViewData["SSN"] = new SelectList(_context.Users, "Id", "Id", orderTable.SSN);
            return View(orderTable);
        }

        // POST: OrderTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Edit(int id, [Bind("Order_Id,date,status,SSN")] OrderTable orderTable)
        {
            if (id != orderTable.Order_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTableExists(orderTable.Order_Id))
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
            ViewData["SSN"] = new SelectList(_context.Users, "Id", "Id", orderTable.SSN);
            return View(orderTable);
        }

        // GET: OrderTables/Delete/5
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderTables == null)
            {
                return NotFound();
            }

            var orderTable = await _context.OrderTables
                .Include(o => o.SSNNavigation)
                .FirstOrDefaultAsync(m => m.Order_Id == id);
            if (orderTable == null)
            {
                return NotFound();
            }

            return View(orderTable);
        }

        // POST: OrderTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderTables == null)
            {
                return Problem("Entity set 'LibrarymanagementsystemContext.OrderTables'  is null.");
            }
            var orderTable = await _context.OrderTables.FindAsync(id);
            if (orderTable != null)
            {
                _context.OrderTables.Remove(orderTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderTableExists(int id)
        {
          return _context.OrderTables.Any(e => e.Order_Id == id);
        }
    }
}
