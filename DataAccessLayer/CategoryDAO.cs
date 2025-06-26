using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        private DataContextSingleton context = DataContextSingleton.Instance;
        public List<Categories> GetAllCategories()
        {
            return context.Categories;
        }
        public void AddCategory(Categories category)
        {
            category.CategoryID = context.Categories.Count > 0 ? context.Categories.Max(c => c.CategoryID) + 1 : 1;
            context.Categories.Add(category);
        }
        public Categories GetCategoryById(int categoryId)
        {
            return context.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
        }
        public void UpdateCategory(Categories category)
        {
            var oldCategory = GetCategoryById(category.CategoryID);
            if (oldCategory != null)
            {
                oldCategory.CategoryID = category.CategoryID;
                oldCategory.CategoryName = category.CategoryName;
                oldCategory.Description = category.Description;
            }
        }
        public bool DeleteCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category != null)
            {
                context.Categories.Remove(category);
                return true;
            }
            return false;
        }
        public bool DeleteCategory(Categories category)
        {
            if (category == null) return false;
            return DeleteCategory(category.CategoryID);
        }
    }
}
