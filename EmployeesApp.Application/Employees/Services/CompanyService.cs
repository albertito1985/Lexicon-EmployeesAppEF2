using EmployeesApp.Application.Employees.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Application.Employees.Services
{
    public class CompanyService(IUnitOfWork unitOfWork): ICompanyService
    {
        public async Task DeleteAsync(int companyId)
        {
            // Logic to delete a company
            // For example, you might want to delete all employees associated with the company first
            var employees = await unitOfWork.EmployeeRepository.GetAllAsync();
            foreach (var employee in employees)
            {
                await unitOfWork.EmployeeRepository.DeleteAsync(employee);
            }
            // Then delete the company itself
            await unitOfWork.CompanyRepository.DeleteAsync(companyId); // Assuming companyId is available
            
            // Finally, persist the changes
            await unitOfWork.PersistAsync();
        }
    }
}
