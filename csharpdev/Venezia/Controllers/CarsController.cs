using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Venezia.Data;
using Venezia.Filters;
using Venezia.Models;

namespace Venezia.Controllers
{
    public class CarsController : Controller
    {
        private readonly VeneziaContext _context;

        public CarsController(VeneziaContext context)
        {
            _context = context;
        }

        private async Task PrepareViewBag()
        {
            ViewBag.Fuels = new SelectList(await _context.Fuel.ToListAsync(), "ID", "Label");
        }

        // GET: Cars
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cars = await _context.Car.Include(x => x.FuelType).ToListAsync();
            return View(cars);
        }

        // GET: Cars/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.Include(x => x.FuelType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //this.ViewBag.Fuels = await _context.Fuel.ToListAsync();
            await PrepareViewBag();
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(AuthFilter))]
        public async Task<IActionResult> Create([Bind("Mark,Model,Price,FuelTypeID,Autonomous")] Car car)
        {
            /*if(car?.Mark?.ToLower() == "peugeot")
            {
                ModelState.AddModelError("Mark", "Pas de peugeot!! ok!!");
            }*/
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            await PrepareViewBag();
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(AuthFilter))]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Mark,Model,Price,FuelTypeID,Autonomous")] Car car)
        {
            if (id != car.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.ID))
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
            await PrepareViewBag();
            return View(car);
        }

        // GET: Cars/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(AuthFilter))]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
