using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDAO
    {
        private DataContextSingleton context = DataContextSingleton.Instance;
        public List<Orders> GetAllOrders()
        {
            return context.Orders;
        }
        public void AddOrder(Orders order)
        {
            order.OrderID = context.Orders.Count > 0 ? context.Orders.Max(o => o.OrderID) + 1 : 1;
            context.Orders.Add(order);
        }
        public Orders GetOrderById(int orderId)
        {
            return context.Orders.FirstOrDefault(o => o.OrderID == orderId);
        }
        public void UpdateOrder(Orders order)
        {
            var oldOrder = GetOrderById(order.OrderID);
            if (oldOrder != null)
            {
                oldOrder.OrderID = order.OrderID;
                oldOrder.CustomerID = order.CustomerID;
                oldOrder.EmployeeID = order.EmployeeID;
                oldOrder.OrderDate = order.OrderDate;
            }
        }
        public bool DeleteOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order != null)
            {
                context.Orders.Remove(order);
                return true;
            }
            return false;
        }
        public bool DeleteOrder(Orders order)
        {
            if (order == null) return false;
            return DeleteOrder(order.OrderID);
        }
    }
}
