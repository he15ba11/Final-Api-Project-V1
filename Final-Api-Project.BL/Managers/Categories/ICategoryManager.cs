using Final_Api_Project.BL.Dtos.Categories;
using Final_Api_Project.BL.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Managers.Categories
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryDto> GetCategories();
        CategoryDetailsDto? GetCategoryDetails(int categoryId);
        void AddCategory(AddCategoryDto addCategoryDto);
        void EditCategory(EditCategoryDto editCategoryDto);
        void DeleteCategory(int categoryId);
    }
}
