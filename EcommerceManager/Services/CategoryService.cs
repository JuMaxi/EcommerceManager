using EcommerceManager.Db;
using EcommerceManager.DbAccess;
using EcommerceManager.Interfaces;
using EcommerceManager.Models.DataBase;

namespace EcommerceManager.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDbAccess _categoryDbAccess;

        public CategoryService(ICategoryDbAccess categoryDbAccess)
        {
            _categoryDbAccess = categoryDbAccess;
        }

        public void InsertNewCategory(Category category)
        {
            category.Parent = _categoryDbAccess.GetCategoryFromDbById(category.Parent.Id);
            _categoryDbAccess.AddNewCategory(category);
        }

        
    }
}
