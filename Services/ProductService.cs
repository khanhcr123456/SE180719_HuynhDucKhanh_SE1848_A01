using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public void AddProduct(Products product)
        {
            productRepository.AddProduct(product);
        }

        public bool DeleteProduct(int productId)
        {
            return productRepository.DeleteProduct(productId);
        }

        public bool DeleteProduct(Products product)
        {
            return productRepository.DeleteProduct(product);
        }

        public List<Products> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Products GetProductById(int productId)
        {
            return productRepository.GetProductById(productId);
        }

        public void UpdateProduct(Products product)
        {
            productRepository.UpdateProduct(product);
        }
    }
}
