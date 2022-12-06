using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2
{
    public class Dental : ICompanyType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }

        public Dental()
        {
            Name = "Dental";
            Description = "A type of healthcare revolving around oral and tooth care.";
            Rate = 0.35;
        }
    }
}
