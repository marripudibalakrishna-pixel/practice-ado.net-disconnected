using Dbconnectivity.ConnectionFactory;
using Entities.Dtos;
using Entities.Interfaces;
using Entities.Models;
using Entities.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_reppsitory
{
    public class EmployeeRepository : IEmployeeRepository
    {
        
        private readonly IConnectionFactory _connectionFactory;

        public EmployeeRepository(IConnectionFactory connectionFactory) 
        {
            _connectionFactory = connectionFactory;
        }
        public async Task <bool> AddEmployee(Employee employee)
        {
            using (SqlConnection con = _connectionFactory.Hotel_dbConnectionstring()) 
            {
                SqlCommand cmd = new SqlCommand(Storedprocedurenames.AddEmployee, con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredProcedureparameters.EmployeeName, employee.name);
                cmd.Parameters.AddWithValue(StoredProcedureparameters.EmployeeSalary, employee.salary);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }
            return true;
            }

        public async Task<bool> DeleteEmployee(int id)
        {
            using(SqlConnection cn =_connectionFactory.Hotel_dbConnectionstring())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedurenames.DeleteEmployee, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredProcedureparameters.EmployeeID, id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            return true;
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            using(SqlConnection cn = _connectionFactory.Hotel_dbConnectionstring())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedurenames.GetEmployee, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                List<Employee> employees = new List<Employee>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Employee employee = new Employee
                    {
                        id = Convert.ToInt32(dr["empid"]),
                        name = Convert.ToString(dr["empname"]),
                        salary = Convert.ToInt32(dr["empsalary"])

                    };
                    employees.Add(employee);
                }
                return Task.FromResult(employees);
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            using (SqlConnection cn = _connectionFactory.Hotel_dbConnectionstring())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedurenames.GetEmployeeByEmpid, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = new DataTable();
                foreach (DataRow row in dt.Rows)
                {
                    emp.name = Convert.ToString(row["empname"]);
                    emp.salary = Convert.ToInt32(row["empsalary"]);

                }
            }
            return emp;

        }
        

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            using (SqlConnection cn = _connectionFactory.Hotel_dbConnectionstring())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedurenames.UpdateEmployee, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredProcedureparameters.EmployeeID, employee.id);
                cmd.Parameters.AddWithValue(StoredProcedureparameters.EmployeeName, employee.name);
                cmd.Parameters.AddWithValue(StoredProcedureparameters.EmployeeSalary, employee.salary);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            return true;

        }
    }
}
