using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.CompanyTypes;

namespace TechTyccoon2.CompanyTypes
{
    public class Restaurant : ICompanyType
    {
        public string Name { get; set; }
        public string Description {get; set; }

        public Restaurant()
        {
            this.Name = "Restaurant";
            this.Description = "This is a physical restaurant business. As you would expect, they manage franchises and sell food for a profit.";
    }
    }
}
