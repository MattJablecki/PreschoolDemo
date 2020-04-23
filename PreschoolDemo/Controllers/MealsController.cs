using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PreschoolDemo.Data;
using PreschoolDemo.Models;
using PreschoolDemo.ViewModels;

namespace PreschoolDemo.Controllers
{
    public class MealsController : Controller
    {
        private readonly PreschoolDemoContext _context;

        public MealsController(PreschoolDemoContext context)
        {
            _context = context;
        }

        // GET: Meals
        public async Task<IActionResult> Index(Guid id)
        {
            var child = await _context.Children.FirstOrDefaultAsync(m => m.Id == id);
            string childName = child.FirstName + " " + child.LastName;

            var index = new MealIndex()
            {
                Meals = await _context.Meals.Where(x => x.Child_Id == id).OrderByDescending(x => x.Date).ToListAsync(),
                ChildName = childName
            };

            return View(index);
        }

        // GET: Meals/Create
        public IActionResult Create(Guid Id)
        {
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "FirstName");
            Meal meal = new Meal();
            meal.Child_Id = Id;            
            return View(meal);
        }

        // POST: Meals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Contents,Notes,Date,Time,Child_Id,Teacher_Id")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                meal.Id = Guid.NewGuid();
                meal.Date = DateTime.Now;
                string y = meal.Time.Remove(2, 1);
                string x = DateTime.ParseExact(y, "HHmm", CultureInfo.CurrentCulture).ToString("hh:mm tt");
                meal.Time = x;
                var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == meal.Teacher_Id);
                meal.TeacherName = teacher.FirstName + " " + teacher.LastName;
                _context.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = meal.Child_Id });
            }
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "FirstName", meal.Teacher_Id);

            return View(meal);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            {
                var meal = await _context.Meals.FindAsync(id);
                _context.Meals.Remove(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = meal.Child_Id });
            }
        }

        private bool MealExists(Guid id)
        {
            return _context.Meals.Any(e => e.Id == id);
        }
    }
}
