﻿using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Interfaces;

public interface IEmployeeRepository
{
    Task AddAsync(Employee employee);
    Task<Employee[]> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    void Delete(Employee employee);
    Task<Employee[]> GetEmployeesByCompanyId(int id);
}