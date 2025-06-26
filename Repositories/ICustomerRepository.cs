using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepository
    {
        public List<Customers> GetAllCustomers();
        public void AddCustomer(Customers customer);
        public Customers GetCustomerById(int customerId);

        public void UpdateCustomer(Customers customers);
        public bool DeleteCustomer(int customerId);
        public bool DeleteCustomer(Customers customer);

    }
}
