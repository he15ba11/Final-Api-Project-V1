using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Data.Models.Products;
using Final_Api_Project.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Repositories.Categories
{
    public class CategoryRepository :  GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(E_CommerceContext context) : base(context)
        {
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }

        public Category GetCategoryDetails(int categoryId)
        {
            return _context.Categories
                .FirstOrDefault(p => p.Id == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = _context.Categories.Find(category.Id);
            if (existingCategory != null)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
            }
        }
    }
}
