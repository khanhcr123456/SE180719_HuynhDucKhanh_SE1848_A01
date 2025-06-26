using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository orderRepository;

        public OrderService()
        {
            orderRepository = new OrderRepository();
        }

        public void CreateOrderWithDetails(int customerId, int employeeId, List<OrderDetails> details)
        {
            var newOrder = new Orders
            {
                OrderID = GetNextOrderId(),
                CustomerID = customerId,
                EmployeeID = employeeId,
                OrderDate = DateTime.Now,
                OrderDetails = details
            };

            orderRepository.AddOrder(newOrder);
        }

        public void AddOrder(Orders order)
        {
            orderRepository.AddOrder(order);
        }

        public bool DeleteOrder(int orderId)
        {
            return orderRepository.DeleteOrder(orderId);
        }

        public bool DeleteOrder(Orders order)
        {
            return orderRepository.DeleteOrder(order);
        }

        public List<Orders> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }

        public Orders GetOrderById(int orderId)
        {
            return orderRepository.GetOrderById(orderId);
        }

        public void UpdateOrder(Orders order)
        {
            orderRepository.UpdateOrder(order);
        }

        public int GetNextOrderId()
        {
            var orders = orderRepository.GetAllOrders();
            return orders.Any() ? orders.Max(o => o.OrderID) + 1 : 1;
        }
        public List<OrderDetails> GetAllOrderDetails()
        {
            return DataAccessLayer.DataContextSingleton.Instance.OrderDetails;
        }

    }
}
