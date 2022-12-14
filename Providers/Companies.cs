using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2;
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

        public enum Types
        {
            Tech,
            Restaurant,
            BookPublishing,
            Dental
        }

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

        public static ICompanyType Industry(Types type)
        {
            switch (type)
            {
                case Types.Tech:
                    return CompanyTypes.First(x => x.Name == "Tech");
                case Types.Restaurant:
                    return CompanyTypes.First(x => x.Name == "Restaurant");
                case Types.BookPublishing:
                    return CompanyTypes.First(x => x.Name == "Book Publishing");
                case Types.Dental:
                    return CompanyTypes.First(x => x.Name == "Dental");
                default:
                    return null;
            }
        }

        public static Company SearchName(string name)
        {
            var c = companies.FirstOrDefault(x => x.Name.ToLower() == name);
            if (c == null)
            {
                return null;
            }

            return c;
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
                description: Slogans.RandomMotto(),
                type: CompanyTypes[r.Next(0, CompanyTypes.Count)],
                initialfunding: r.Next(4999, 101000)
                );

            return generated;

        }

    }

    public static class CompanyType
    {
        public static Tech TechCompany = new Tech();
        public static Restaurant Restaurant = new Restaurant();
        public static BookPublishing BookPublishing = new BookPublishing();
        public static Dental Dental = new Dental();

    }
}
