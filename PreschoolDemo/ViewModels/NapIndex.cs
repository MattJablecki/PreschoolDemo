using PreschoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreschoolDemo.ViewModels
{
    public class NapIndex
    {
        public string ChildName { get; set; }

        public List<Nap> Naps { get; set; }
    }
}
