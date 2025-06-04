using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Infrastructure.Persistance.Repositories;

public class CompanyRepository(ApplicationContext context) : ICompanyRepository
{
    public async Task<Company?> GetAsync(int companyId)
    {
        return await context.Companies.FindAsync(companyId);
    }

    public async Task DeleteAsync(int companyId)
    {
        var company = await GetAsync(companyId);
        if (company is null)
        {
            throw new ArgumentException($"Invalid parameter value: {companyId}", nameof(companyId));
        }
        context.Companies.Remove(company);
    }
}
