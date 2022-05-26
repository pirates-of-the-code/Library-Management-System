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
using Microsoft.AspNetCore.Identity;
using LibraryManagementSystem.Areas.Identity.Pages.Account;
using Microsoft.AspNet.Identity;

namespace LibraryManagementSystem.Controllers
{

    
    public class BooksController : Controller
    {
        private readonly LibrarymanagementsystemContext _context;
        private readonly ILogger<RegisterModel> _logger;

        public BooksController(LibrarymanagementsystemContext context, ILogger<RegisterModel> logger )
        {
            _context = context;
            _logger = logger;
        }



        // GET: Books

        [Authorize(Roles = "Admin, Employee, Customer")]

        public async Task<IActionResult> Index()
        {
              return View(await _context.Books.ToListAsync());
        }


        public IActionResult UserBooksPage()
        {
            if (User.IsInRole("Admin"))
            {
                return LocalRedirect("/Books/AdminBooks");

            }
            else if(User.IsInRole("Employee"))
            {
                return LocalRedirect("/Books/AdminBooks");

            }
            else
            {
                return LocalRedirect("/Books/Index");
            }
        }


        [Authorize(Roles = "Admin, Employee, Customer")]

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Admin, Employee")]
        
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult AdminBooks()
        {
            return View(_context.Books.ToList());
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]

        public async Task<IActionResult> Create([Bind("title,ISBN,Price,image,License_Quantity")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminBooks));
            }
            return View(book);
        }
        [Authorize(Roles = "Admin, Employee")]

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> Edit(int id, [Bind("title,ISBN,Price,image,License_Quantity")] Book book)
        {
            if (id != book.ISBN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.ISBN))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AdminBooks));
            }
            return View(book);
        }

        // GET: Books/Delete/5

        [Authorize(Roles = "Admin, Employee")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'LibrarymanagementsystemContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AdminBooks));
        }
        public async Task<IActionResult> Orders(String ISBNs)
        {
            OrderTable orderTable = new OrderTable();
            orderTable.date = DateTime.Now.ToString();
            orderTable.status = 0;
            orderTable.SSN= User.Identity.GetUserId();
            List<int> isbns= new List<int>();
            ISBNs.Split(',').ToList().ForEach(a=> { if (a.Length > 0) isbns.Add(int.Parse(a)); });
            var books = new List<Book>();

            foreach (var isb in isbns)
            {
                books.Add(await _context.Books.FindAsync(isb));
            }

            orderTable.ISBNs = books;
            _context.OrderTables.Add(orderTable);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return _context.Books.Any(e => e.ISBN == id);
        }
    }
}
