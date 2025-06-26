using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DataContextSingleton
    {
        private static DataContextSingleton _instance;

        public static DataContextSingleton Instance => _instance ??= new DataContextSingleton();

        // Dữ liệu
        public List<Customers> Customers { get; set; } = new List<Customers>();
        public List<Employees> Employees { get; set; } = new List<Employees>();
        public List<Products> Products { get; set; } = new List<Products>();
        public List<Categories> Categories { get; set; } = new List<Categories>();
        public List<Orders> Orders { get; set; } = new List<Orders>();
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        private DataContextSingleton()
        {
            SeedData();
        }

        private void SeedData()
        {
            // Categories
            Categories = new List<Categories>
            {
                new Categories { CategoryID = 1, CategoryName = "Beverages", Description = "Drinks and beverages" },
                new Categories { CategoryID = 2, CategoryName = "Snacks", Description = "Snack foods" }
            };

            // Products
            Products = new List<Products>
            {
                new Products { ProductID = 1, ProductName = "Coca Cola", CategoryID = 1, UnitPrice = 10000, UnitsInStock = 100 },
                new Products { ProductID = 2, ProductName = "Pepsi", CategoryID = 1, UnitPrice = 9000, UnitsInStock = 80 },
                new Products { ProductID = 3, ProductName = "Potato Chips", CategoryID = 2, UnitPrice = 15000, UnitsInStock = 50 }
            };

            // Customers
            Customers = new List<Customers>
            {
                new Customers { CustomerID = 1, CompanyName = "ABC Corp", ContactName = "Nguyen Van A", ContactTitle = "Manager", Address = "123 Le Loi", Phone = "0909123456" },
                new Customers { CustomerID = 2, CompanyName = "XYZ Ltd", ContactName = "Tran Thi B", ContactTitle = "Director", Address = "456 Tran Hung Dao", Phone = "0911222333" }
            };

            // Employees
            Employees = new List<Employees>
            {
                new Employees { EmployeeID = 1, Name = "Huynh Duc Khanh", UserName = "khanh", Password = "123", JobTitle = "Admin" },
                new Employees { EmployeeID = 2, Name = "Nguyen Van A", UserName = "customer", Password = "123", JobTitle = "Customer" }
            };

            // Orders
            Orders = new List<Orders>
            {
                new Orders { OrderID = 1, CustomerID = 1, EmployeeID = 1, OrderDate = DateTime.Now.AddDays(-2) },
                new Orders { OrderID = 2, CustomerID = 2, EmployeeID = 2, OrderDate = DateTime.Now.AddDays(-1) }
            };

            // OrderDetails
            OrderDetails = new List<OrderDetails>
            {
                new OrderDetails { OrderID = 1, ProductID = 1, UnitPrice = 10000, Quantity = 2 },
                new OrderDetails { OrderID = 1, ProductID = 3, UnitPrice = 15000, Quantity = 1 },
                new OrderDetails { OrderID = 2, ProductID = 2, UnitPrice = 9000, Quantity = 3 }
            };

            // Gán OrderDetails vào từng Orders để tính TotalAmount
            foreach (var order in Orders)
            {
                order.OrderDetails = OrderDetails
                    .Where(od => od.OrderID == order.OrderID)
                    .ToList();
            }
        }
    }
}
