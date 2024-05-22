using Final_Api_Project.BL.Managers.Products;
using Final_Api_Project.BL.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Final_Api_Project.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts(string category = null, string name = null)
        {
            var products = _productManager.GetProducts(category, name);
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public ActionResult<ProductDetailsDTO> GetProductDetails(int productId)
        {
            var productDetails = _productManager.GetProductDetails(productId);
            if (productDetails == null)
                return NotFound();

            return productDetails;
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductDTO addProductDto)
        {
            _productManager.AddProduct(addProductDto);
            var createdProductUrl = Url.Action(nameof(GetProductDetails), new { id = addProductDto.Id });
            return Created(createdProductUrl, addProductDto);
        }

        [HttpPut("{productId}")]
        public ActionResult EditProduct(int productId, EditProductDTO editProductDto)
        {
            if (productId != editProductDto.Id)
            {
                return BadRequest("Product ID mismatch.");
            }

            _productManager.EditProduct(editProductDto);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(int productId)
        {
            _productManager.DeleteProduct(productId);
            return NoContent();
        }
    }
}
