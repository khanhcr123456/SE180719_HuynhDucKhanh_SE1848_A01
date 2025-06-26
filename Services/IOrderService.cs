using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService
    {
        public List<Orders> GetAllOrders();
        public void AddOrder(Orders order);
        public Orders GetOrderById(int orderId);
        public void UpdateOrder(Orders order);
        public bool DeleteOrder(int orderId);
        public bool DeleteOrder(Orders order);
        public int GetNextOrderId();
        List<OrderDetails> GetAllOrderDetails();
    }
}
