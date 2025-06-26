using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private DataContextSingleton context = DataContextSingleton.Instance;
        public List<Customers> GetAllCustomers()
        {
            return context.Customers;
        }
        public void AddCustomer(Customers customer)
        {
            customer.CustomerID = context.Customers.Count > 0 ? context.Customers.Max(c => c.CustomerID) + 1 : 1;
            context.Customers.Add(customer);
        }
        public Customers GetCustomerById(int customerId)
        {
            return context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
        }

        public void UpdateCustomer(Customers customers)
        {
            var oldCustomer = GetCustomerById(customers.CustomerID);
            if (oldCustomer != null)
            {
                oldCustomer.CompanyName = customers.CompanyName;
                oldCustomer.ContactName = customers.ContactName;
                oldCustomer.ContactTitle = customers.ContactTitle;
                oldCustomer.Address = customers.Address;
                oldCustomer.Phone = customers.Phone;
            }
        }
        public bool DeleteCustomer(int customerId)
        {
            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                return true;
            }
            return false;
        }
        public bool DeleteCustomer(Customers customer)
        {
            if (customer == null) return false;
            return DeleteCustomer(customer.CustomerID);

        }
    }
}
