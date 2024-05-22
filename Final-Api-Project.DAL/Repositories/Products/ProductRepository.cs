using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Data.Models;
using Final_Api_Project.DAL.Data.Models.Products;
using Final_Api_Project.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Api_Project.DAL.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(E_CommerceContext context) : base(context)
        {
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public Product GetProductDetails(int productId)
        {
            return _context.Products
                .FirstOrDefault(p => p.Id == productId);
        }

        public IEnumerable<Product> GetProducts(string category = null, string name = null)
        {
            IQueryable<Product> query = _context.Products;
            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(p => p.Category.Name.Contains(category));
            }


            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            return query.ToList();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }

        }
    }
}
