using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.CompanyTypes;

namespace TechTyccoon2.CompanyTypes
{
    public class TechCompany : ICompanyType
    {
        public string Name { get; set; }
        public string Description {get; set; }

        public TechCompany()
        {
            this.Name = "Tech";
            this.Description = "This is a tech company, they build electronics such as computers and smartphones for sale to the general public";
    }
    }
}
