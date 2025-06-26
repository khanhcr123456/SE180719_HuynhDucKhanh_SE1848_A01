using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HuynhDucKhanhWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            var manageCustomersWindow = new ManageCustomersWindow();
            manageCustomersWindow.ShowDialog();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            var manageCustomersWindow = new ManageProductsWindow();
            manageCustomersWindow.ShowDialog();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            var createAndViewWindow = new CreateAndViewWindow();
            createAndViewWindow.ShowDialog();
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            var createAndViewWindow = new OrderReportWindow();
            createAndViewWindow.ShowDialog();
        }
    }
}