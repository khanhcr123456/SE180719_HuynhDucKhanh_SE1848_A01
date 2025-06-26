using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDetailsDAO
    {
        private DataContextSingleton context = DataContextSingleton.Instance;
        public List<OrderDetails> GetAllOrderDetails()
        {
            return context.OrderDetails;
        }

        public void AddOrderDetail(OrderDetails orderDetail)
        {
            context.OrderDetails.Add(orderDetail);
        }
        public OrderDetails GetOrderDetailById(int orderId)
        {
            return context.OrderDetails.FirstOrDefault(od => od.OrderID == orderId);
        }

        public void UpdateOrderDetail(OrderDetails orderDetail)
        {
            var oldOrderDetail = GetOrderDetailById(orderDetail.OrderID);
            if (oldOrderDetail != null)
            {
                oldOrderDetail.OrderID = orderDetail.OrderID;
                oldOrderDetail.ProductID = orderDetail.ProductID;
                oldOrderDetail.UnitPrice = orderDetail.UnitPrice;
                oldOrderDetail.Quantity = orderDetail.Quantity;
                oldOrderDetail.Discount = orderDetail.Discount;
            }

        }
        public bool DeleteOrderDetail(int orderId)
        {
            var orderDetail = GetOrderDetailById(orderId);
            if (orderDetail != null)
            {
                context.OrderDetails.Remove(orderDetail);
                return true;
            }
            return false;
        }

        public bool DeleteOrderDetail(OrderDetails orderDetail)
        {
            if (orderDetail == null) return false;
            return DeleteOrderDetail(orderDetail.OrderID);
        }
    }
}
