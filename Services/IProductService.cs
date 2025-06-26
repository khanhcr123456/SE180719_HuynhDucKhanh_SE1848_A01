using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        public List<Products> GetAllProducts();

        public void AddProduct(Products product);

        public Products GetProductById(int productId);

        public void UpdateProduct(Products product);
        public bool DeleteProduct(int productId);
        public bool DeleteProduct(Products product);
    }
}
