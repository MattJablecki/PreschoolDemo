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
    public class NapsController : Controller
    {
        private readonly PreschoolDemoContext _context;

        public NapsController(PreschoolDemoContext context)
        {
            _context = context;
        }

        // GET: Naps
        public async Task<IActionResult> Index(Guid id)
        {
            var child = await _context.Children.FirstOrDefaultAsync(m => m.Id == id);
            string childName = child.FirstName + " " + child.LastName;

            var index = new NapIndex()
            {
                Naps = await _context.Naps.Where(x => x.Child_Id == id).OrderByDescending(x => x.Date).ToListAsync(),
                ChildName = childName
            };

            return View(index);
        }

        // GET: Naps/Create
        public IActionResult Create(Guid Id)
        {
            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "FirstName");
            Nap nap = new Nap();
            nap.Child_Id = Id;
            return View(nap);
        }

        // POST: Naps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,StartTime,EndTime,Notes,Child_Id,Teacher_Id")] Nap nap)
        {
            if (ModelState.IsValid)
            {
                nap.Id = Guid.NewGuid();
                nap.Date = DateTime.Now;
                string y = nap.StartTime.Remove(2, 1);
                string x = DateTime.ParseExact(y, "HHmm", CultureInfo.CurrentCulture).ToString("hh:mm tt");
                nap.StartTime = x;
                string z = nap.EndTime.Remove(2, 1);
                string a = DateTime.ParseExact(z, "HHmm", CultureInfo.CurrentCulture).ToString("hh:mm tt");
                nap.EndTime = a;
                var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == nap.Teacher_Id);
                nap.TeacherName = teacher.FirstName + " " + teacher.LastName;
                _context.Add(nap);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = nap.Child_Id });
            }

            ViewData["Teacher"] = new SelectList(_context.Teachers, "Id", "FirstName", nap.Teacher_Id);

            return View(nap);
        }

        // GET: Naps/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            {
                var nap = await _context.Naps.FindAsync(id);
                _context.Naps.Remove(nap);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = nap.Child_Id });
            }
        }

        private bool NapExists(Guid id)
        {
            return _context.Naps.Any(e => e.Id == id);
        }
    }
}
