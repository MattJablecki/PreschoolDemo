using PreschoolDemo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreschoolDemo.Models
{
    public class Diaper
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public DiaperType Type { get; set; }
        
        public Guid Child_Id { get; set; }

        public string ChildName { get; set; }

        public Guid Teacher_Id { get; set; }

        public string TeacherName { get; set; }

        public string Notes { get; set; }

    }
}
