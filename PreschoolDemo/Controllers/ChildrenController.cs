using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PreschoolDemo.Data;
using PreschoolDemo.Models;

namespace PreschoolDemo.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly PreschoolDemoContext _context;

        public ChildrenController(PreschoolDemoContext context)
        {
            _context = context;
        }

        // GET: Children
        public async Task<IActionResult> Index()
        {
            return View(await _context.Children.ToListAsync());
        }

        // GET: Children/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhotoPath")] Child child)
        {
            if (ModelState.IsValid)
            {
                child.Id = Guid.NewGuid();
                _context.Add(child);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(child);
        }

        // GET: Children/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            {
                var child = await _context.Children.FindAsync(id);
                _context.Children.Remove(child);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ChildExists(Guid id)
        {
            return _context.Children.Any(e => e.Id == id);
        }
    }
}
