using EcommerceManager.Interfaces;
using EcommerceManager.Models.DataBase;

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

        public async Task InsertNewCategory(Category category)
        {
            await _validateCategory.Validate(category);
            category.Parent = await _categoryDbAccess.GetCategoryFromDbById(category.Parent.Id);
            await _categoryDbAccess.AddNewCategory(category);
        }

        public List<Category> GetAllCategoriesFromDb()
        {
            List<Category> categories = _categoryDbAccess.GetListCategoriesFromDb();
            return categories;
        }

        public async Task UpdateCategory(Category category)
        {
            await _validateCategory.Validate(category);

            Category toUpdate = await _categoryDbAccess.GetCategoryFromDbById(category.Id);

            toUpdate.Name = category.Name;
            toUpdate.Description = category.Description;
            toUpdate.Image = category.Image;
            
            if(category.Parent != null)
            {
                Category parent = new();
                parent = await _categoryDbAccess.GetCategoryFromDbById(category.Parent.Id);
                toUpdate.Parent = parent;
            }

            _categoryDbAccess.UpdateCategory(toUpdate);
        }
        
        public void DeleteCategory(int id) 
        { 
            _categoryDbAccess.DeleteCategory(id);
        }
    }
}
