using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;


namespace LibraryManagementSystem.Controllers
{
    public class AspNetUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _context;

        public AspNetUsersController(UserManager<ApplicationUser> context)
        {
            _context = context;
        }

        // get: aspnetusers
        public IActionResult index()
        {
            return View(_context.Users.ToList()); ;
        }
        //to do list

        // GET: AspNetUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.FindByIdAsync(id);
            
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return View(aspNetUser);
        }

        // GET: AspNetUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,PasswordHash,PhoneNumber")] ApplicationUser appUser)
        {
            if (ModelState.IsValid)
            {
             //   _context.Add(aspNetUser);
           
                var result = await _context.CreateAsync(appUser, appUser.PasswordHash);


                if (result.Succeeded)
                {

                    await _context.AddToRoleAsync(appUser, "Employee");

                    return RedirectToAction(nameof(Index));


                }
            }
            return NoContent();
        }

        // GET: AspNetUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.FindByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,Email,PhoneNumber")] ApplicationUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                var _appUser=  await  _context.FindByIdAsync(appUser.Id);
                    await _context.UpdateAsync(_appUser);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await AspNetUserExists(appUser.Id))
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
            return View(appUser);
        }

        // GET: AspNetUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.FindByIdAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var _applicationUser = await _context.FindByIdAsync(id);
            await  _context.DeleteAsync(_applicationUser);
          
            return RedirectToAction(nameof(Index));
        }

        private async Task <bool> AspNetUserExists(string id)
        {
            return await _context.FindByIdAsync(id)!=null;
        }
    }
}
