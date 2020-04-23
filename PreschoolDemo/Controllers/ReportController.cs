using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PreschoolDemo.Data;
using PreschoolDemo.ViewModels;

namespace PreschoolDemo.Controllers
{
    public class ReportController : Controller
    {
        private readonly PreschoolDemoContext _context;

        public ReportController(PreschoolDemoContext context)
        {
            _context = context;
        }
        public IActionResult Index(Guid id)
        {
            var child = _context.Children.FirstOrDefault(m => m.Id == id);
            string childName = child.FirstName + " " + child.LastName;
            var diapers = _context.Diapers.Where(m => m.Child_Id == id && m.Date.Date == DateTime.Now.Date).ToList();
            var naps = _context.Naps.Where(m => m.Child_Id == id && m.Date.Date == DateTime.Now.Date).ToList();
            var meals = _context.Meals.Where(m => m.Child_Id == id && m.Date.Date == DateTime.Now.Date).ToList();
            var report = new DailyReport
            {
                ChildName = childName,
                Diapers = diapers,
                Meals = meals,
                Naps = naps,
                DateTime = DateTime.Now
            };

            return View(report);
        }
    }
}