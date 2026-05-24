using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IEmployeeRepository
    {
        public  Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(int id);

        public Task<bool> AddEmployee(Employee employee);
            public Task<bool> UpdateEmployee(Employee employee);
            public Task<bool> DeleteEmployee(int id);
    }
}
