using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeDAO
    {
        private DataContextSingleton context = DataContextSingleton.Instance;
        public List<Employees> GetAllEmployees()
        {
            return context.Employees;
        }

        public void AddEmployee(Employees employee)
        {
            employee.EmployeeID = context.Employees.Count > 0 ? context.Employees.Max(e => e.EmployeeID) + 1 : 1;
            context.Employees.Add(employee);
        }

        public Employees GetEmployeeById(int employeeId)
        {
            return context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
        }

        public Employees Login(string username, string password)
        {
            return context.Employees.FirstOrDefault(e =>
        e.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
        && e.Password == password); ;
        }
        public void UpdateEmployee(Employees employee)
        {
            var oldEmployee = GetEmployeeById(employee.EmployeeID);
            if (oldEmployee != null)
            {
                oldEmployee.EmployeeID = employee.EmployeeID;
                oldEmployee.Name = employee.Name;
                oldEmployee.UserName = employee.UserName;
                oldEmployee.Password = employee.Password;
                oldEmployee.JobTitle = employee.JobTitle;
            }
        }
        public bool DeleteEmployee(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                return true;
            }
            return false;
        }
        public bool DeleteEmployee(Employees employee)
        {
            if (employee == null) return false;
            return DeleteEmployee(employee.EmployeeID);
        }
    }
}
