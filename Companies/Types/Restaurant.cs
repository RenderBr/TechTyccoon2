using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2
{
    public class Restaurant : ICompanyType
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double Rate { get; set; }
        public Restaurant()
        {
            Name = "Restaurant";
            Description = "This is a physical restaurant business. As you would expect, they manage franchises and sell food for a profit.";
            Rate = -0.1;
        }
    }
}
