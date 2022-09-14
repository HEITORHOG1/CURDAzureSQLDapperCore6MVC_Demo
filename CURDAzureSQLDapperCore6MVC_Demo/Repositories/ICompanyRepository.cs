using CURDAzureSQLDapperCore6MVC_Demo.Models;

namespace CURDAzureSQLDapperCore6MVC_Demo.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int? id);
        Task CreateCompany(Company company);
        Task UpdateCompany(int id, Company company);
        Task DeleteCompany(int id);
    }
}
