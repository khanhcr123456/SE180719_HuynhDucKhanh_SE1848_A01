using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects;
using Services;

namespace HuynhDucKhanhWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IEmployeeService iEmployeeService;
        public LoginWindow()
        {
            InitializeComponent();
            iEmployeeService = new EmployeeService();
        }

       

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Employees employee = iEmployeeService.Login(username, password);

            if (employee != null)
            {
                if (employee.JobTitle == "Admin")
                {
                    new MainWindow().Show();
                    this.Close();
                }
                else if (employee.JobTitle == "Customer")
                {

                    var customerService = new CustomerService();
                    var customer = customerService.GetAllCustomers()
                        .FirstOrDefault(c => c.ContactName == employee.Name);

                    if (customer != null)
                    {
                        AppSession.CurrentCustomer = customer;
                        new CustomerWindow().Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Customer data not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
