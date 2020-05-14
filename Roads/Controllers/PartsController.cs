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
        public async Task<ActionResult> Index(string searchString, string filter)
        {
            var user = await GetCurrentUserAsync();
            var parts = await _context.Part
                .Where(ti => ti.ApplicationUserId == user.Id)
                .Include(tdi => tdi.ApplicationUser)
                .Include(tdi => tdi.PartType)
                .ToListAsync();

            switch (filter)
            {
                case "Tire & Rims":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.PartTypeId == 1)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                case "Engine & Exhaust":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.PartTypeId == 2)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                case "Turbos & Superchargers":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.PartTypeId == 3)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                case "Brakes, Suspension, & Chasis":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.PartTypeId == 5)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                case "Fuel System":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.PartTypeId == 6)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                case "Coolant & Air System":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.PartTypeId == 7)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                case "Transmission":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.PartTypeId == 9)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                case "Body Parts":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.PartTypeId == 10)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                case "Other":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.PartTypeId == 11)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                case "All":
                    parts = await _context.Part
                        //.Where(ti => ti.UserId == user.Id)
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
                default:
                    parts = await _context.Part
                        .Include(ti => ti.PartType)
                        .ToListAsync();
                    break;
            }

            if (searchString != null)
            {
                var filteredParts = _context.Part.Where(s => s.Name.Contains(searchString) || s.Brand.Contains(searchString));
                return View(filteredParts);
            };

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
            var partTypeOptions = await _context.PartType.Select(p => new SelectListItem() 
            { 
                Text = p.Name,
                Value = p.Id.ToString() 
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



        // GET: Parts/Edit/1
        public async Task<ActionResult> Edit(int id)
        {
            var partTypes = await _context.PartType.Select(p => new SelectListItem() 
            { 
                Text = p.Name, 
                Value = p.Id.ToString() 
            })
               .ToListAsync();
            var part = await _context.Part.FirstOrDefaultAsync(p => p.Id == id);
            var viewModel = new PartFormViewModel()
            {
                Name = part.Name,
                Brand = part.Brand,
                ImagePath = part.ImagePath,
                PartTypeId = part.PartTypeId,
                PartTypeOptions = partTypes,
            };

            return View(viewModel);
        }


        // POST: Parts/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PartFormViewModel partFormView)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var parts = new Part()
                {
                    Id = id,
                    Name = partFormView.Name,
                    Brand = partFormView.Brand,
                    ImagePath = partFormView.ImagePath,
                    ApplicationUserId = user.Id,
                    PartTypeId = partFormView.PartTypeId,
                };               

                _context.Part.Update(parts);
                await _context.SaveChangesAsync();
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: Parts/Delete/1
        public async Task<ActionResult> Delete(int id)
        {
            var partt = await _context.Part
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (partt == null)
            {
                return NotFound();
            }

            return View(partt);
        }


        // POST: Parts/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                //TODO: Add delete logic here
                var partt = await _context.Part.FindAsync(id);
                _context.Part.Remove(partt);
                await _context.SaveChangesAsync();
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