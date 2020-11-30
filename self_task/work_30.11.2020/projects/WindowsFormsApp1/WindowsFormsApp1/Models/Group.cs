using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Specialty_id { get; set; }
        public string Name { get; set; }
        public Specialty Specialty { get; set; }
    }
}
