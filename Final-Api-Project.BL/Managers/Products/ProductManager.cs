using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Repositories.Products;
using Final_Api_Project.BL.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using Final_Api_Project.DAL;
using Final_Api_Project.DAL.Data.Models.Products;

namespace Final_Api_Project.BL.Managers.Products
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddProduct(AddProductDTO addProductDto)
        {
            var product = new Product
            {
                Name = addProductDto.Name,
                Description = addProductDto.Description,
                CategoryId = addProductDto.CategoryId,
                Price = addProductDto.Price,
                ImageUrl = addProductDto.ImageUrl
            };
            _unitOfWork.ProductRepository.AddProduct(product);
        }

        public void DeleteProduct(int productId) { 
            _unitOfWork.ProductRepository.DeleteProduct(productId);
        }

        public void EditProduct(EditProductDTO editProductDto)
        {
            var product = _unitOfWork.ProductRepository.GetProductDetails(editProductDto.Id);
            if (product != null)
            {
                product.Name = editProductDto.Name;
                product.CategoryId = editProductDto.CategoryId;
                product.Price = editProductDto.Price;
                product.ImageUrl = editProductDto.ImageUrl;
                _unitOfWork.ProductRepository.UpdateProduct(product);
            }
        }

        public ProductDetailsDTO? GetProductDetails(int productId)
        {
            var product = _unitOfWork.ProductRepository.GetProductDetails(productId);
            if (product != null)
            {
                return new ProductDetailsDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl
                };
            }
            return null;
        }

        public IEnumerable<ProductDTO> GetProducts(string category = null, string name = null)
        {
            var products = _unitOfWork.ProductRepository.GetProducts(category, name);
            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            });
        }
    }
}
