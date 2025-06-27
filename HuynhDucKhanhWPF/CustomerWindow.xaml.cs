using BusinessObjects;
using Services;
using System.Linq;
using System.Windows;

namespace HuynhDucKhanhWPF
{
    public partial class CustomerWindow : Window
    {
        private readonly IOrderService orderService = new OrderService();
        private readonly ICustomerService customerService = new CustomerService();
        private Customers currentCustomer;

        public CustomerWindow()
        {
            InitializeComponent();

            currentCustomer = AppSession.CurrentCustomer;

            if (currentCustomer == null)
            {
                MessageBox.Show("Customer session not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            LoadProfile();
            LoadOrderHistory();
        }

        private void LoadProfile()
        {
            txtContactName.Text = currentCustomer.ContactName;
            txtAddress.Text = currentCustomer.Address;
            txtPhone.Text = currentCustomer.Phone;
        }

        private void btnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            currentCustomer.ContactName = txtContactName.Text.Trim();
            currentCustomer.Address = txtAddress.Text.Trim();

            customerService.UpdateCustomer(currentCustomer);

            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadOrderHistory()
        {
            var orders = orderService.GetAllOrders()
                .Where(o => o.CustomerID == currentCustomer.CustomerID)
                .Select(o => new
                {
                    o.OrderID,
                    o.OrderDate,
                    TotalAmount = o.OrderDetails?.Sum(d => d.UnitPrice * d.Quantity) ?? 0
                }).ToList();

            dgOrderHistory.ItemsSource = orders;
        }
    }
}
