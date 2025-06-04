﻿using EmployeesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Application.Employees.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<Company> GetAsync(int companyId);
        public Task DeleteAsync(int companyId);
    }
}
