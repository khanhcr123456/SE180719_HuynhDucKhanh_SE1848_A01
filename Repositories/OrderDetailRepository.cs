using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        OrderDetailsDAO orderDetailsDAO = new OrderDetailsDAO();
        public void AddOrderDetail(OrderDetails orderDetail)
        {
            orderDetailsDAO.AddOrderDetail(orderDetail);
        }

        public bool DeleteOrderDetail(int orderId)
        {
            return orderDetailsDAO.DeleteOrderDetail(orderId);
        }

        public bool DeleteOrderDetail(OrderDetails orderDetail)
        {
            return orderDetailsDAO.DeleteOrderDetail(orderDetail);
        }

        public List<OrderDetails> GetAllOrderDetails()
        {
            return orderDetailsDAO.GetAllOrderDetails();
        }

        public OrderDetails GetOrderDetailById(int orderId)
        {
            return orderDetailsDAO.GetOrderDetailById(orderId);
        }

        public void UpdateOrderDetail(OrderDetails orderDetail)
        {
            orderDetailsDAO.UpdateOrderDetail(orderDetail);
        }
    }
}
