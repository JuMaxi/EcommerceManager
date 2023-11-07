using EcommerceManager.Db;
using EcommerceManager.DbAccess;
using EcommerceManager.Interfaces;
using EcommerceManager.Models.DataBase;
using EcommerceManager.Models.Requests;

namespace EcommerceManager.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDbAccess _categoryDbAccess;
        private readonly IValidateCategory _validateCategory;

        public CategoryService(ICategoryDbAccess categoryDbAccess, IValidateCategory validateCategory)
        {
            _categoryDbAccess = categoryDbAccess;
            _validateCategory = validateCategory;
        }

        public void InsertNewCategory(Category category)
        {
            _validateCategory.Validate(category);
            category.Parent = _categoryDbAccess.GetCategoryFromDbById(category.Parent.Id);
            _categoryDbAccess.AddNewCategory(category);
        }

        
    }
}
