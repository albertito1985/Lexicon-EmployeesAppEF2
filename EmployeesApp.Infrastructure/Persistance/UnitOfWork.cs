using EmployeesApp.Application.Employees.Interfaces;

namespace EmployeesApp.Infrastructure.Persistance;

public class UnitOfWork(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, ApplicationContext context) : IUnitOfWork
{
    public IEmployeeRepository EmployeeRepository { get; } = employeeRepository;
    public ICompanyRepository CompanyRepository { get; } = companyRepository;

    //public ICompanyRepository CompanyRepository => throw new NotImplementedException();

    public async Task PersistAsync()
    {
        await context.SaveChangesAsync();
    }

}
