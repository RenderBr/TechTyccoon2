using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.CompanyTypes;

namespace TechTyccoon2
{
    public class Company
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICompanyType Type { get; set; }

        public double CurrentFunds { get; set; }

        public double StartupFunds { get; private set; }

        public double SuccessRate { get; set; }

        public List<CompanyRecord> CompanyRecords { get; set; } = new List<CompanyRecord>();

        public Company(string name, string description, ICompanyType type, double initialfunding = 10000, double successRate = 0.5)
        {
            Name = name;
            Description = description;
            Type = type;
            StartupFunds = initialfunding;
            CurrentFunds = StartupFunds;
            SuccessRate = successRate;
        }

        public int Index()
        {
            int i = Companies.companies.IndexOf(this);
            return i;
        }

        public virtual void ModifySuccesRate(double rate)
        {
            SuccessRate = SuccessRate + rate;
        }
    }
}
