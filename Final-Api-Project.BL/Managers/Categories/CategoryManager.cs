using Final_Api_Project.BL.Dtos.Categories;
using Final_Api_Project.BL.Dtos.Products;
using Final_Api_Project.BL.Managers.Products;
using Final_Api_Project.DAL;
using Final_Api_Project.DAL.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Managers.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       public void AddCategory(AddCategoryDto addCategoryDto)
        {
            var category = new Category
            {
                Name = addCategoryDto.Name,
                Description = addCategoryDto.Description,
            };
            _unitOfWork.CategoryRepository.AddCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _unitOfWork.CategoryRepository.DeleteCategory(categoryId);
        }

        public void EditCategory(EditCategoryDto editCategoryDto)
        {
            var category = _unitOfWork.CategoryRepository.GetCategoryDetails(editCategoryDto.Id);
            if (category != null)
            {
                category.Name = editCategoryDto.Name;
                category.Description = editCategoryDto.Description;

                _unitOfWork.CategoryRepository.UpdateCategory(category);
            }
        }

        public IEnumerable<CategoryDto>GetCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetCategories();
            return categories.Select(p => new CategoryDto
            {
                Id = p.Id,
                Name = p.Name,
                Description= p.Description,
            });
        }

        public CategoryDetailsDto? GetCategoryDetails(int categoryId)
        {
            var category = _unitOfWork.CategoryRepository.GetCategoryDetails(categoryId);
            if (category != null)
            {
                return new CategoryDetailsDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }
            return null;
        }
    }
}
