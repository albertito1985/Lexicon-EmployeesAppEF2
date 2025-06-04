using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Services;

public class CompanyService(IUnitOfWork unitOfWork) : ICompanyService
{
    public async Task DeleteAsync(int companyId)
    {
        // Logic to delete a company
        // For example, you might want to delete all employees associated with the company first
        var employees = await GetEmployeesByCompanyId(companyId);
        foreach (var employee in employees)
        {
            unitOfWork.EmployeeRepository.Delete(employee);
        }
        // Then delete the company itself
        await unitOfWork.CompanyRepository.DeleteAsync(companyId); // Assuming companyId is available

        // Finally, persist the changes
        await unitOfWork.PersistAsync();
    }

    public async Task<Employee[]> GetEmployeesByCompanyId(int id) => await unitOfWork.EmployeeRepository.GetEmployeesByCompanyId(id);
}
