using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALINQ24091601
{
    internal class Pet
    {
        public int Age => (int)(DateTime.Now - BirthDate).TotalDays / 365;
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string Species { get; set; }
    }
}
