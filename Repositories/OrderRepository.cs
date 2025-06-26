using BusinessObjects;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class OrderRepository
    {
        private List<Orders> orders;

        public OrderRepository()
        {
            orders = DataContextSingleton.Instance.Orders;
        }

     

        public bool DeleteOrder(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order != null)
            {
                orders.Remove(order);
                return true;
            }
            return false;
        }

        public bool DeleteOrder(Orders order)
        {
            return DeleteOrder(order.OrderID);
        }

        public List<Orders> GetAllOrders()
        {
            return orders;
        }

        public Orders GetOrderById(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderID == orderId);
        }

        public void UpdateOrder(Orders updated)
        {
            var existing = GetOrderById(updated.OrderID);
            if (existing != null)
            {
                existing.CustomerID = updated.CustomerID;
                existing.EmployeeID = updated.EmployeeID;
                existing.OrderDate = updated.OrderDate;
                existing.OrderDetails = updated.OrderDetails;
            }
        }
        public void AddOrder(Orders order)
        {
            var db = DataContextSingleton.Instance;
            db.Orders.Add(order);

            if (order.OrderDetails != null && order.OrderDetails.Count > 0)
            {
                db.OrderDetails.AddRange(order.OrderDetails);
            }
        }

    }
}
