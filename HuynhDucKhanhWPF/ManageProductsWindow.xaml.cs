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
    /// Interaction logic for ManageProductsWindow.xaml
    /// </summary>
    public partial class ManageProductsWindow : Window
    {
        private IProductService productService;
        public ManageProductsWindow()
        {
            InitializeComponent();
            productService = new ProductService();
            LoadProducts();
        }
        private void LoadProducts()
        {
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = productService.GetAllProducts();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItem is Products selectedProduct)
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    productService.DeleteProduct(selectedProduct.ProductID);
                    LoadProducts();
                    ClearTextBoxes();
                }
            }

            else
            {
                MessageBox.Show("Please select a product to delete.", "Delete Product", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItem is Products selected)
            {
                selected.ProductName = txtProductName.Text;
                selected.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                selected.UnitsInStock = int.Parse(txtUnitsInStock.Text);
                selected.CategoryID = int.Parse(txtCategoryID.Text);
                productService.UpdateProduct(selected);
                lvProduct.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a product to update.", "Update Product", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var product = productService.GetAllProducts();
            var newProduct = new Products
            {
                ProductName = txtProductName.Text,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = int.Parse(txtUnitsInStock.Text),
                CategoryID = int.Parse(txtCategoryID.Text)
            };
            productService.AddProduct(newProduct);
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = productService.GetAllProducts();
            ClearTextBoxes();
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProduct.SelectedItem is Products selectedProduct)
            {
                txtProductID.Text = selectedProduct.ProductID.ToString();
                txtProductName.Text = selectedProduct.ProductName;
                txtUnitPrice.Text = selectedProduct.UnitPrice.ToString("F2");
                txtUnitsInStock.Text = selectedProduct.UnitsInStock.ToString();
                txtCategoryID.Text = selectedProduct.CategoryID.ToString();
            }
            else
            {
                txtProductID.Clear();
                txtProductName.Clear();
                txtUnitPrice.Clear();
                txtUnitsInStock.Clear();
                txtCategoryID.Clear();
            }
        }
        private void ClearTextBoxes()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtUnitsInStock.Clear();
            txtCategoryID.Clear();
        }
    }
}
