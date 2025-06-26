using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetails> GetAllOrderDetails();

        public void AddOrderDetail(OrderDetails orderDetail);
        public OrderDetails GetOrderDetailById(int orderId);

        public void UpdateOrderDetail(OrderDetails orderDetail);
        public bool DeleteOrderDetail(int orderId);

        public bool DeleteOrderDetail(OrderDetails orderDetail);
    }
}
