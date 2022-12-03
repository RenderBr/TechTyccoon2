using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2
{
    public class CompanyRecord
    {
        public int Year { get ; set; }
        public int NetGain { get; set; }

        public CompanyRecord(int year, int netGain)
        {
            Year = year;
            NetGain = netGain;
        }
    }
}
