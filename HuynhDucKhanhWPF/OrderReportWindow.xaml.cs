using BusinessObjects;
using Services;
using System;
using System.Linq;
using System.Windows;

namespace HuynhDucKhanhWPF
{
    public partial class OrderReportWindow : Window
    {
        private readonly IOrderService orderService = new OrderService();
        private readonly ICustomerService customerService = new CustomerService();
        private readonly IEmployeeService employeeService = new EmployeeService();

        public OrderReportWindow()
        {
            InitializeComponent();
            dpFromDate.SelectedDate = DateTime.Today.AddMonths(-1);
            dpToDate.SelectedDate = DateTime.Today;
        }

        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fromDate = dpFromDate.SelectedDate;
            DateTime? toDate = dpToDate.SelectedDate;

            if (fromDate == null || toDate == null)
            {
                MessageBox.Show("Please select both From and To dates.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var orders = orderService.GetAllOrders()
                .Where(o => o.OrderDate.Date >= fromDate && o.OrderDate.Date <= toDate)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            foreach (var order in orders)
            {
                if (order.OrderDetails == null)
                {
                    order.OrderDetails = orderService.GetAllOrderDetails()
                        .Where(d => d.OrderID == order.OrderID).ToList();
                }
            }

            var reportData = orders.Select(o => new
            {
                o.OrderID,
                CustomerName = customerService.GetCustomerById(o.CustomerID)?.ContactName ?? "Unknown",
                EmployeeName = employeeService.GetEmployeeById(o.EmployeeID)?.Name ?? "Unknown",
                o.OrderDate,
                TotalAmount = o.OrderDetails.Sum(d => d.UnitPrice * d.Quantity)
            }).ToList();

            dgReports.ItemsSource = reportData;
        }
    }
}
