using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistance
{
    public class UnitOfWork(IEmployeeRepository employeeRepository, ICompnayRepository companyRepository, ApplicationContext context)
    {
        public IEmployeeRepository EmployeeRepository { get; } = employeeRepository;
        public ICompnayRepository CompnayRepository { get; } = companyRepository;

        public async Task PersistAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
