using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private DataContextSingleton context = DataContextSingleton.Instance;
        public List<Products> GetAllProducts()
        {
            return context.Products;
        }

        public void AddProduct(Products product)
        {
            product.ProductID = context.Products.Count > 0 ? context.Products.Max(p => p.ProductID) + 1 : 1;
            context.Products.Add(product);
        }

        public Products GetProductById(int productId)
        {
            return context.Products.FirstOrDefault(p => p.ProductID == productId);
        }

        public void UpdateProduct(Products product)
        {
            var oldProduct = GetProductById(product.ProductID);
            if (oldProduct != null)
            {
                oldProduct.ProductName = product.ProductName;
                oldProduct.CategoryID = product.CategoryID;
                oldProduct.UnitPrice = product.UnitPrice;
                oldProduct.UnitsInStock = product.UnitsInStock;

            }

        }
        public bool DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                context.Products.Remove(product);
                return true;
            }
            return false;
        }
        public bool DeleteProduct(Products product)
        {
            if (product == null) return false;
            return DeleteProduct(product.ProductID);
        }
    }
}
