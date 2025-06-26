using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO = new ProductDAO();
        public void AddProduct(Products product)
        {
            productDAO.AddProduct(product);
        }
        public bool DeleteProduct(int productId)
        {
            return productDAO.DeleteProduct(productId);
        }
        public bool DeleteProduct(Products product)
        {
            return productDAO.DeleteProduct(product);
        }
        public List<Products> GetAllProducts()
        {
            return productDAO.GetAllProducts();
        }

        public Products GetProductById(int productId)
        {
            return productDAO.GetProductById(productId);
        }

        public void UpdateProduct(Products product)
        {
            productDAO.UpdateProduct(product);
        }
    }
}
