using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDAO employeeDAO = new EmployeeDAO();

        public void AddEmployee(Employees employee)
        {
            employeeDAO.AddEmployee(employee);
        }

        public bool DeleteEmployee(int employeeId)
        {
            return employeeDAO.DeleteEmployee(employeeId);
        }

        public bool DeleteEmployee(Employees employees)
        {
            return employeeDAO.DeleteEmployee(employees);
        }

        public List<Employees> GetAllEmployees()
        {
            return employeeDAO.GetAllEmployees();
        }

        public Employees GetEmployeeById(int employeeId)
        {
            return employeeDAO.GetEmployeeById(employeeId);
        }

        public Employees Login(string username, string password)
        {
            return employeeDAO.Login(username, password);
        }

        public void UpdateEmployee(Employees employee)
        {
            employeeDAO.UpdateEmployee(employee);
        }
    }
}
