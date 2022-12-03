using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.CompanyTypes;
using TechTyccoon2.Utilities;

namespace TechTyccoon2
{
    public static class Companies
    {
        public static List<Company> companies = new List<Company>();
        public static List<ICompanyType> CompanyTypes = new List<ICompanyType>() {
            CompanyType.TechCompany, 
            CompanyType.Restaurant, 
            CompanyType.BookPublishing, 
            CompanyType.Dental 
        }; 

        public static void Add(Company company)
        {
            companies.Add(company);
        }

        /// <summary>
        /// Searches for an index and retrieves the Company object.
        /// </summary>
        /// <param name="Search Index"></param>
        /// <returns></returns>
        public static Company SearchIndex(int index)
        {
            return companies[index];
        }

        public static int Count()
        {
            return companies.Count;
        }

        public static Company GenerateRandomCompany()
        {
            Random r = new Random();

            Company generated = new Company(
                name: $"{Utils.GenerateCompanyName()}",
                description: "This is a random company :)",
                type: CompanyTypes[r.Next(0, CompanyTypes.Count)],
                initialfunding: r.Next(4999, 101000)
                );

            return generated;

        }

    }

    public static class CompanyType
    {
        public static Tech TechCompany = new Tech();
        public static Restaurant Restaurant= new Restaurant();
        public static BookPublishing BookPublishing = new BookPublishing();
        public static Dental Dental = new Dental();


    }
}
