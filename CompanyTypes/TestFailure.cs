using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.CompanyTypes;

namespace TechTyccoon2.CompanyTypes
{
    public class TestFailure : ICompanyType
    {
        public string Name { get; set; }
        public string Description {get; set; }

        public double Rate { get; set; }
        public TestFailure()
        {
            this.Name = "TestFailure";
            this.Description = "Intended for testing purposes.";
            this.Rate = 0;
        }
    }
}
