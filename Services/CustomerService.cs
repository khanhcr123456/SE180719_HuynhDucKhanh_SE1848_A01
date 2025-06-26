using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository customerRepository;
        public CustomerService()
        {
            customerRepository = new CustomerRepository();
        }

        public void AddCustomer(Customers customer)
        {
            customerRepository.AddCustomer(customer);
        }

        public bool DeleteCustomer(int customerId)
        {
            return customerRepository.DeleteCustomer(customerId);
        }

        public bool DeleteCustomer(Customers customer)
        {
            return customerRepository.DeleteCustomer(customer);
        }

        public List<Customers> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        public Customers GetCustomerById(int customerId)
        {
            return customerRepository.GetCustomerById(customerId);
        }

        public void UpdateCustomer(Customers customers)
        {
            customerRepository.UpdateCustomer(customers);
        }
    }
}
