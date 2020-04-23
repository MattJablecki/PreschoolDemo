using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreschoolDemo.Models
{
    public class Meal
    {
        public Guid Id { get; set; }

        public string Contents { get; set; }

        public Guid Child_Id { get; set; }

        public string ChildName { get; set; }

        public Guid Teacher_Id { get; set; }

        public string TeacherName { get; set; }

        public string Notes { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }
    }
}
