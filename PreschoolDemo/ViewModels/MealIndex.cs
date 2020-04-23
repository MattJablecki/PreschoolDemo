using PreschoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreschoolDemo.ViewModels
{
    public class MealIndex
    {
        public string ChildName { get; set; }

        public List<Meal> Meals { get; set; }
    }
}
