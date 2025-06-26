using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        public List<Categories> GetAllCategories();
        public void AddCategory(Categories category);
        public Categories GetCategoryById(int categoryId);
        public void UpdateCategory(Categories category);
        public bool DeleteCategory(int categoryId);
        public bool DeleteCategory(Categories category);


    }
}
