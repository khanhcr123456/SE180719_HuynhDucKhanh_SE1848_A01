using BusinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HuynhDucKhanhWPF
{
    public partial class CreateAndViewWindow : Window
    {
        private readonly ICustomerService customerService = new CustomerService();
        private readonly IEmployeeService employeeService = new EmployeeService();
        private readonly IProductService productService = new ProductService();
        private readonly IOrderService orderService = new OrderService();

        private List<OrderDetails> orderDetails = new List<OrderDetails>();

        public CreateAndViewWindow()
        {
            InitializeComponent();
            cbCustomer.ItemsSource = customerService.GetAllCustomers();
            cbEmployee.ItemsSource = employeeService.GetAllEmployees();
            cbProduct.ItemsSource = productService.GetAllProducts();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var allOrders = orderService.GetAllOrders();

            foreach (var order in allOrders)
            {
                if (order.OrderDetails == null || order.OrderDetails.Count == 0)
                {
                    order.OrderDetails = orderService.GetAllOrderDetails()
                        .Where(d => d.OrderID == order.OrderID)
                        .ToList();
                }
            }

            var orderViewModels = allOrders.Select(order => new
            {
                order.OrderID,
                order.CustomerID,
                order.EmployeeID,
                order.OrderDate,
                TotalAmount = order.OrderDetails?.Sum(d => d.UnitPrice * d.Quantity) ?? 0
            }).ToList();

            dgOrders.ItemsSource = orderViewModels;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (cbProduct.SelectedItem is Products product &&
                int.TryParse(txtQty.Text, out int qty))
            {
                orderDetails.Add(new OrderDetails
                {
                    ProductID = product.ProductID,
                    UnitPrice = product.UnitPrice,
                    Quantity = qty
                });

                lstOrderDetails.Items.Add($"{product.ProductName} - Quantity: {qty}");
                txtQty.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid quantity.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (cbCustomer.SelectedItem is Customers customer &&
                cbEmployee.SelectedItem is Employees employee &&
                orderDetails.Count > 0)
            {
                var newOrder = new Orders
                {
                    OrderID = orderService.GetNextOrderId(),
                    CustomerID = customer.CustomerID,
                    EmployeeID = employee.EmployeeID,
                    OrderDate = DateTime.Now,
                    OrderDetails = orderDetails
                };


                foreach (var od in orderDetails)
                {
                    od.OrderID = newOrder.OrderID;
                }

                orderService.AddOrder(newOrder);

                MessageBox.Show("Order created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                ClearForm();
                LoadOrders(); 
            }
            else
            {
                MessageBox.Show("Please fill all information before creating order.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearForm()
        {
            cbCustomer.SelectedIndex = -1;
            cbEmployee.SelectedIndex = -1;
            cbProduct.SelectedIndex = -1;
            txtQty.Clear();
            orderDetails.Clear();
            lstOrderDetails.Items.Clear();
        }
    }
}
