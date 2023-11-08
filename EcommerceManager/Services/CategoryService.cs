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

        public List<Category> GetAllCategoriesFromDb()
        {
            List<Category> categories = _categoryDbAccess.GetListCategoriesFromDb();
            return categories;
        }

        public void UpdateCategory(Category category)
        {
            _validateCategory.Validate(category);

            Category toUpdate = _categoryDbAccess.GetCategoryFromDbById(category.Id);

            toUpdate.Name = category.Name;
            toUpdate.Description = category.Description;
            toUpdate.Image = category.Image;

            Category parent = new();
            if(category.Parent != null)
            {
                parent = _categoryDbAccess.GetCategoryFromDbById(category.Parent.Id);
            }
            toUpdate.Parent = parent;

            _categoryDbAccess.UpdateCategory(toUpdate);
        }
        
    }
}
