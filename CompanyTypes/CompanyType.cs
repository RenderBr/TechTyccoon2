namespace TechTyccoon2.CompanyTypes
{
    public interface ICompanyType
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract double Rate { get; set; }

    }
}