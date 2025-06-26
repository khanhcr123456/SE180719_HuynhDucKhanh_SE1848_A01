using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEmployeeRepository
    {
        public List<Employees> GetAllEmployees();

        public void AddEmployee(Employees employee);

        public Employees GetEmployeeById(int employeeId);
        public void UpdateEmployee(Employees employee);

        public bool DeleteEmployee(int employeeId);

        public bool DeleteEmployee(Employees employees);
        public Employees Login(string username, string password);
    }
}
