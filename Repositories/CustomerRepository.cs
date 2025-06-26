using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerDAO customerDAO = new CustomerDAO();

        public void AddCustomer(Customers customer)
        {
            customerDAO.AddCustomer(customer);
        }

        public bool DeleteCustomer(int customerId)
        {
            return customerDAO.DeleteCustomer(customerId);
        }

        public bool DeleteCustomer(Customers customer)
        {
            return customerDAO.DeleteCustomer(customer);
        }

        public List<Customers> GetAllCustomers()
        {
            return customerDAO.GetAllCustomers();
        }

        public Customers GetCustomerById(int customerId)
        {
            return customerDAO.GetCustomerById(customerId);
        }

        public void UpdateCustomer(Customers customers)
        {
            customerDAO.UpdateCustomer(customers);
        }
    }
}
