using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class CompanyRepository(ApplicationContext context): ICompanyRepository
    {
        public async Task<Company> GetAsync(int companyId)
        {
            
        }

        public async Task Remove(int companyId)
        {

        }
    }
}
