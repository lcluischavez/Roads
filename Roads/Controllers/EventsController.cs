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
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)

        {

            _context = context;
            _userManager = userManager;

        }


        // GET: Events
        public async Task<ActionResult> Index(string searchString, string filter)
        {
            var user = await GetCurrentUserAsync();
            var events = await _context.Event
                .Where(ti => ti.ApplicationUserId == user.Id)
                .Include(tdi => tdi.ApplicationUser)
                .Include(tdi => tdi.EventType)
                .ToListAsync();

            switch (filter)
            {
                case "Tire & Rims":
                    events = await _context.Event
                        //.Where(ti => ti.UserId == user.Id)
                        .Where(ti => ti.EventTypeId == 1)
                        //.Where(p => p.Quantity > 0)
                        .Include(ti => ti.EventType)
                        .ToListAsync();
                    break;
                case "All":
                    events = await _context.Event
                        //.Where(ti => ti.UserId == user.Id)
                        .Include(ti => ti.EventType)
                        .ToListAsync();
                    break;
                default:
                    events = await _context.Event
                        .Include(ti => ti.EventType)
                        .ToListAsync();
                    break;
            }

            if (searchString != null)
            {
                var filteredEvents = _context.Event.Where(s => s.Name.Contains(searchString) || s.City.Contains(searchString));
                return View(filteredEvents);
            };

            return View(events);
        }



        // GET: Events/Details/1
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventt = await _context.Event
               //.Where(p => p.UserId == user.Id)
               .Include(p => p.ApplicationUser)
               .Include(p => p.EventType)
               .FirstOrDefaultAsync(p => p.Id == id);

            if (eventt == null)
            {
                return NotFound();
            }

            return View(eventt);
        }



        // GET: Events/Create
        public async Task<ActionResult> Create()
        {
            var eventTypeOptions = await _context.EventType.Select(e => new SelectListItem()
            {
                Text = e.Name,
                Value = e.Id.ToString()
            })
                .ToListAsync();
            var viewModel = new EventFormViewModel();
            viewModel.EventTypeOptions = eventTypeOptions;
            return View(viewModel);
        }


        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventFormViewModel eventFormView)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var events = new Event()
                {
                    Name = eventFormView.Name,
                    City = eventFormView.City,
                    Address = eventFormView.Address,
                    SecondaryAddress = eventFormView.SecondaryAddress,
                    Description = eventFormView.Description,
                    ImagePath = eventFormView.ImagePath,
                    ApplicationUserId = user.Id,
                    EventTypeId = eventFormView.EventTypeId,
                };


                _context.Event.Add(events);
                await _context.SaveChangesAsync();

                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: Events/Edit/1
        public async Task<ActionResult> Edit(int id)
        {
            var eventTypes = await _context.EventType.Select(e => new SelectListItem()
            {
                Text = e.Name,
                Value = e.Id.ToString()
            })
               .ToListAsync();
            var eventt = await _context.Event.FirstOrDefaultAsync(e => e.Id == id);
            var viewModel = new EventFormViewModel()
            {
                Name = eventt.Name,
                City = eventt.City,
                Address = eventt.Address,
                SecondaryAddress = eventt.SecondaryAddress,
                ImagePath = eventt.ImagePath,
                EventTypeId = eventt.EventTypeId,
                EventTypeOptions = eventTypes,
            };

            return View(viewModel);
        }


        // POST: Parts/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EventFormViewModel eventFormView)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var events = new Event()
                {
                    Id = id,
                    Name = eventFormView.Name,
                    City = eventFormView.City,
                    Address = eventFormView.Address,
                    SecondaryAddress = eventFormView.SecondaryAddress,
                    ImagePath = eventFormView.ImagePath,
                    ApplicationUserId = user.Id,
                    EventTypeId = eventFormView.EventTypeId,
                };

                _context.Event.Update(events);
                await _context.SaveChangesAsync();
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: Events/Delete/1
        public async Task<ActionResult> Delete(int id)
        {
            var eventt = await _context.Event
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (eventt == null)
            {
                return NotFound();
            }

            return View(eventt);
        }


        // POST: Events/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                //TODO: Add delete logic here
                var eventt = await _context.Event.FindAsync(id);
                _context.Event.Remove(eventt);
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