using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistance
{
    public class UnitOfWork(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, ApplicationContext context) : IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; } = employeeRepository;
        public ICompanyRepository CompnayRepository { get; } = companyRepository;

        public ICompanyRepository CompanyRepository => throw new NotImplementedException();

        public async Task PersistAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
