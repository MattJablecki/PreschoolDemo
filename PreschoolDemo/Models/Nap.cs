using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreschoolDemo.Models
{
    public class Nap
    {
        public Guid Id { get; set; }

        public Guid Child_Id { get; set; }

        public string ChildName { get; set; }

        public Guid Teacher_Id { get; set; }

        public string TeacherName { get; set; }

        public DateTime Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Notes { get; set; }

    }
}
