using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetAllEmployees();
        public Task<EmployeeDto> GetEmployeeById(int id);

        public Task<bool> AddEmployee(EmployeeDto employee);
        public Task<bool> UpdateEmployee(EmployeeDto employee);
        public Task<bool> DeleteEmployee(int id);
    }
}
