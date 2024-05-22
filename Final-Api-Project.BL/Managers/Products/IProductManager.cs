using Final_Api_Project.BL.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Managers.Products
{
    public interface IProductManager
    {
        IEnumerable<ProductDTO> GetProducts(string category = null, string name = null);
        ProductDetailsDTO? GetProductDetails(int productId);
        void AddProduct(AddProductDTO addProductDto);
        void EditProduct(EditProductDTO editProductDto);
        void DeleteProduct(int productId);
    }
}
