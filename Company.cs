using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.CompanyTypes;
using TechTyccoon2.Utilities;

namespace TechTyccoon2
{
    public class Company
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public bool Defunct { get; set; }

        public ICompanyType Type { get; set; }

        private int employeecount = 0;
        public int EmployeeCount { get { return employeecount; } set { if (employeecount == 0) { employeecount = 0; } employeecount = value; } }

        public double CurrentFunds { get; set; }

        public double StartupFunds { get; private set; }

        private double successrate;
        public double SuccessRate { get { return successrate; } set { if (value >= 1) { successrate = 0.95; } successrate = value; } }

        public List<CompanyRecord> CompanyRecords { get; set; } = new List<CompanyRecord>();

        public Company(string name, string description, ICompanyType type, double initialfunding = 10000, double successRate = 0.5)
        {
            Name = name;
            Defunct = false;
            Description = description;
            Type = type;
            StartupFunds = initialfunding;
            CurrentFunds = StartupFunds;
            EmployeeCount = Utils.Random(1, 10);
            Location = Utilities.Countries.RandomCountry();
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
