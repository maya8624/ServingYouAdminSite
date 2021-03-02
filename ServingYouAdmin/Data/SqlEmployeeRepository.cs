using Microsoft.EntityFrameworkCore;
using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly ServingYouContext context;

        public SqlEmployeeRepository(ServingYouContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Employee employee) 
        {
            await context.Employees.AddAsync(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await context.Employees
                        .Where(e => e.IsDeleted == false)
                        .ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await context.Employees.FindAsync(id);
        }
                
        public void Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = EntityState.Modified;
        }      
    }
}
