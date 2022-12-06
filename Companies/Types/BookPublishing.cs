using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2
{
    public class BookPublishing : ICompanyType
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double Rate { get; set; }
        public BookPublishing()
        {
            Name = "Book Publishing";
            Description = "A publishing company sells and distributes books (and magazines, newspapers, digital content, etc.).";
            Rate = 0.25;
        }
    }
}
