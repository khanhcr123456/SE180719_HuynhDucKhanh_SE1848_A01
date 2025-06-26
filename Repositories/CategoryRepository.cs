using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        CategoryDAO categoryDAO = new CategoryDAO();

        public void AddCategory(Categories category)
        {
            categoryDAO.AddCategory(category);
        }

        public bool DeleteCategory(int categoryId)
        {
            return categoryDAO.DeleteCategory(categoryId);
        }

        public bool DeleteCategory(Categories category)
        {
            return categoryDAO.DeleteCategory(category);
        }

        public List<Categories> GetAllCategories()
        {
            return categoryDAO.GetAllCategories();
        }

        public Categories GetCategoryById(int categoryId)
        {
            return categoryDAO.GetCategoryById(categoryId);
        }

        public void UpdateCategory(Categories category)
        {
            categoryDAO.UpdateCategory(category);
        }
    }
}
