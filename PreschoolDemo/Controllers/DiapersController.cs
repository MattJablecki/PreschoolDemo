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
    public class DiapersController : Controller
    {
        private readonly PreschoolDemoContext _context;

        public DiapersController(PreschoolDemoContext context)
        {
            _context = context;
        }

        // GET: Diapers
        public async Task<IActionResult> Index(Guid id)
        {
            var child = await _context.Children.FirstOrDefaultAsync(m => m.Id == id);
            string childName = child.FirstName + " " + child.LastName;

            var index = new DiaperIndex()
            {
                Diapers = await _context.Diapers.Where(x => x.Child_Id == id).OrderByDescending(x => x.Date).ToListAsync(),
                ChildName = childName
            };
            
            return View(index);
        }

        // GET: Diapers/Create
        public async Task<IActionResult> Create(Guid Id)
        {
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "FirstName");
            Diaper diaper = new Diaper();
            diaper.Child_Id = Id;
            var child = await _context.Children.FirstOrDefaultAsync(m => m.Id == Id);
            diaper.ChildName = child.FirstName + " " + child.LastName;
            return View(diaper);
        }

        // POST: Diapers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Notes,Date,Time,Child_Id,Teacher_Id,ChildName,Type")]Diaper diaper)
        {
            
            if (ModelState.IsValid)
            {
                diaper.Id = Guid.NewGuid();
                diaper.Date = DateTime.Now;
                string y = diaper.Time.Remove(2, 1);
                string x = DateTime.ParseExact(y, "HHmm", CultureInfo.CurrentCulture).ToString("hh:mm tt");
                diaper.Time = x;
                var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == diaper.Teacher_Id);
                diaper.TeacherName = teacher.FirstName + " " + teacher.LastName;
                _context.Add(diaper);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = diaper.Child_Id });
            }

            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "FirstName", diaper.Teacher_Id);

            return View(diaper);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            {
                var diaper = await _context.Diapers.FindAsync(id);
                _context.Diapers.Remove(diaper);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = diaper.Child_Id });
            }
        }

        private bool DiaperExists(Guid id)
        {
            return _context.Diapers.Any(e => e.Id == id);
        }
    }
}
