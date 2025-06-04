using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Infrastructure.Persistance.Repositories;

public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
{
    // TODO: The interface has been updated as well
    public async Task AddAsync(Employee employee)
    {
        await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync(); // Inte glömma!
    }

    // TODO: Added AsNoTracking() & Include()
    public async Task<Employee[]> GetAllAsync() =>
            await context.Employees.AsNoTracking().Include(o => o.Company).ToArrayAsync();

    public async Task<Employee?> GetByIdAsync(int id) => await context.Employees
        .FindAsync(id);

    public void Delete(Employee employee)
    {
        if (employee is null)
        {
            throw new ArgumentNullException(nameof(employee), "Employee cannot be null");
        }
        context.Employees.Remove(employee);
        //await context.SaveChangesAsync();
    }

    public async Task<Employee[]> GetEmployeesByCompanyId(int id) => await context.Employees.Where(e => e.CompanyId == id).ToArrayAsync();
}