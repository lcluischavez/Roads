using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roads.Data;
using Roads.Models;

namespace Roads.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)

        {

            _context = context;
            _userManager = userManager;

        }


        // GET: Cars
        public async Task<ActionResult> Index(string searchString)
        {
            var user = await GetCurrentUserAsync();
            var cars = await _context.Car
                .Where(ti => ti.ApplicationUserId == user.Id)
                .Include(tdi => tdi.ApplicationUser)
                .ToListAsync();

            if (searchString != null)
            {
                var filteredCars = _context.Car.Where(s => s.Make.Contains(searchString) || s.Model.Contains(searchString));
                return View(filteredCars);
            };

            return View(cars);
        }


        // GET: Cars/Details/1
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
               //.Where(p => p.UserId == user.Id)
               .Include(p => p.ApplicationUser)
               .FirstOrDefaultAsync(p => p.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }



        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Car car)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                car.ApplicationUserId = user.Id;

                _context.Car.Add(car);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: Cars/Edit/1
        public ActionResult Edit(int id)
        {
            return View();
        }


        // POST: Cars/Edit/1
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



        // GET: Cars/Delete/1
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: Cars/Delete/1
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