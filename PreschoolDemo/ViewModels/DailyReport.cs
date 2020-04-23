using PreschoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreschoolDemo.ViewModels
{
    public class DailyReport
    {
        public string ChildName { get; set; }

        public List<Diaper> Diapers { get; set; }

        public List<Nap> Naps { get; set; }

        public List<Meal> Meals { get; set; }

        public DateTime DateTime { get; set; }
    }
}
