using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2
{
    public class Tech : ICompanyType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }

        public Tech()
        {
            Name = "Tech";
            Description = "This is a tech company, they build electronics such as computers and smartphones for sale to the general public";
            Rate = 0.1;
        }
    }
}
