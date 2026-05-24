using Entities.Dtos;
using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_service
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> AddEmployee(EmployeeDto employee)
        {
            Employee emp = new Employee();
            emp.id = employee.id;
            emp.name = employee.name;
            emp.salary = employee.salary;
            await _employeeRepository.AddEmployee(emp);
            return true;
        }



       

        public async Task<bool> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return true;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            List<EmployeeDto> emplistdto = new List<EmployeeDto>();
            var emplist = await _employeeRepository.GetAllEmployees();
            foreach (var emp in emplistdto)
            {
                EmployeeDto empdto = new EmployeeDto();
                empdto.id = emp.id;
                empdto.name = emp.name;
                empdto.salary = emp.salary;
                emplistdto.Add(empdto);

            }

            return emplistdto;
        }
            

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            EmployeeDto empdto = new EmployeeDto();
            var result = await _employeeRepository.GetEmployeeById(id);
            //empdto.id = result.Id;
            empdto.name = result.name;
            empdto.salary = result.salary;
            return empdto;
        }

        public async Task<bool> UpdateEmployee(EmployeeDto employee)
        {
            Employee emp = new Employee();
            emp.id = employee.id;
            emp.name = employee.name;
            emp.salary = employee.salary;
            await _employeeRepository.UpdateEmployee(emp);
            return true;
        }
    }
}
