using Dbconnectivity.ConnectionFactory;
using Employee_service;
using Entities.Dtos;
using Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Employeecontroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILoggingFactory _loggingFactory;
        public EmployeeController(IEmployeeService employeeService, ILoggingFactory loggingFactory)
        {
            _employeeService = employeeService;
            _loggingFactory = loggingFactory;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        
        public async Task<IActionResult> GetAllEmployees()
        {
            Log.Information("get method execution started");
            await _loggingFactory.IlogMessages("bala", "information", "getmethod started");

            var result = await _employeeService.GetAllEmployees();
            Log.Information("get method execution ended");

            return Ok(result);
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeDto employee)
        {
            Log.Information("post method execution started");

           await  _loggingFactory.IlogMessages("bala", "information", $"getmethod started with name{employee.name}");
            await _loggingFactory.IlogMessages("bala", "information", $"getmethod started with salary{employee.salary}");

            var result = await _employeeService.AddEmployee(employee);
            Log.Information("post method execution ended");

            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetEmployeeById(id);
            return Ok(result);
        }
    }
}