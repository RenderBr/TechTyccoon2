using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.CompanyTypes;

namespace TechTyccoon2.CompanyTypes
{
    public class Dental : ICompanyType
    {
        public string Name { get; set; }
        public string Description {get; set; }
        public double Rate { get; set; }

        public Dental()
        {
            this.Name = "Dental";
            this.Description = "A type of healthcare revolving around oral and tooth care.";
            this.Rate = 0.35;
        }
    }
}
