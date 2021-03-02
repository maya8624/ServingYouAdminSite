

using System.Collections.Generic;
using System.Threading.Tasks;
using ServingYouAdmin.Models;

namespace ServingYouAdmin.Data
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeAsync(int id);

        Task<IEnumerable<Employee>> GetAllEmployeeAsync();

        Task AddAsync(Employee employee);

        void Update(Employee employee);
    }
}
