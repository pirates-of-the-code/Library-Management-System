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
using Microsoft.AspNetCore.Authorization;
//using LibraryManagementSystem.Areas.Identity.Pages.Account;

namespace LibraryManagementSystem.Controllers
{
    
    [Authorize(Roles="Admin")]
    public class AspNetUsersController : Controller
    {

        //Admin@Admin
        //P@$$w0rd


        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
    //    private readonly ILogger<RegisterModel> _logger;
    //    private readonly IEmailSender _emailSender;

        public AspNetUsersController(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager)
    //        ILogger<RegisterModel> logger,
      //      IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            //_emailStore = (IUserEmailStore<ApplicationUser>)GetEmailStore();
            _signInManager = signInManager;
        //    _logger = logger;
          //  _emailSender = emailSender;
        }

        // get: aspnetusers
        public IActionResult index()
        {
            return View(_userManager.Users.ToList()); ;
        }
        //to do list

        // GET: AspNetUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUser = await _userManager.FindByIdAsync(id);
            
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
        public async Task<IActionResult> Create([Bind("Email,UserName,PasswordHash,PhoneNumber")] ApplicationUser appUser)
        {
            if (ModelState.IsValid)
            {
             //   _context.Add(aspNetUser);
           
                var result = await _userManager.CreateAsync(appUser, appUser.PasswordHash);


                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(appUser, "Employee");

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

            var appUser = await _userManager.FindByIdAsync(id);
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
                var _appUser=  await  _userManager.FindByIdAsync(appUser.Id);
                    await _userManager.UpdateAsync(_appUser);
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

            var applicationUser = await _userManager.FindByIdAsync(id);
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
            var _applicationUser = await _userManager.FindByIdAsync(id);
            await  _userManager.DeleteAsync(_applicationUser);
          
            return RedirectToAction(nameof(Index));
        }

        private async Task <bool> AspNetUserExists(string id)
        {
            return await _userManager.FindByIdAsync(id)!=null;
        }
    }
}
