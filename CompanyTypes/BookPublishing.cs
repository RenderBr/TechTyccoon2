using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.CompanyTypes;

namespace TechTyccoon2.CompanyTypes
{
    public class BookPublishing : ICompanyType
    {
        public string Name { get; set; }
        public string Description {get; set; }

        public double Rate { get; set; }
        public BookPublishing()
        {
            this.Name = "Book Publishing";
            this.Description = "A publishing company sells and distributes books (and magazines, newspapers, digital content, etc.).";
            this.Rate = 0.25;
        }
    }
}
