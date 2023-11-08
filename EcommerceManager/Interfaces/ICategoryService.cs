using EcommerceManager.Models.DataBase;
using EcommerceManager.Models.Requests;

namespace EcommerceManager.Interfaces
{
    public interface ICategoryService
    {
        public Task InsertNewCategory(Category category);
        public List<Category> GetAllCategoriesFromDb();
        public Task UpdateCategory(Category category);
        public void DeleteCategory(int id);
    }
}
