using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Group_id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Group Group { get; set; }
    }
}
