using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Roads.Data;
using Roads.Models;
using Roads.Models.ViewModels;

namespace Roads.Controllers
{
    public class PartsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PartsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)

        {

            _context = context;
            _userManager = userManager;

        }

        // GET: Parts
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var parts = await _context.Part
                .Where(ti => ti.ApplicationUserId == user.Id)
                .Include(tdi => tdi.ApplicationUser)
                .Include(tdi => tdi.PartType)
                .ToListAsync();

            return View(parts);
        }

        // GET: Parts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partt = await _context.Part
               //.Where(p => p.UserId == user.Id)
               .Include(p => p.ApplicationUser)
               .Include(p => p.PartType)
               .FirstOrDefaultAsync(p => p.Id == id);

            if (partt == null)
            {
                return NotFound();
            }

            return View(partt);
        }

        // GET: Parts/Create
        public async Task<ActionResult> Create()
        {
            var partTypeOptions = await _context.PartType.Select(g => new SelectListItem() 
            { 
                Text = g.Name,
                Value = g.Id.ToString() 
            })
                .ToListAsync();
            var viewModel = new PartFormViewModel();
            viewModel.PartTypeOptions = partTypeOptions;
            return View(viewModel);
        }


        // POST: Parts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PartFormViewModel partFormView)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var parts = new Part()
                {
                    Name = partFormView.Name,
                    Brand = partFormView.Brand,
                    ImagePath = partFormView.ImagePath,
                    ApplicationUserId = user.Id,
                    PartTypeId = partFormView.PartTypeId,
                };

                
                _context.Part.Add(parts);
                await _context.SaveChangesAsync();

                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Parts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}