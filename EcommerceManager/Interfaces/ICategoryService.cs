using EcommerceManager.Models.DataBase;
using EcommerceManager.Models.Requests;

namespace EcommerceManager.Interfaces
{
    public interface ICategoryService
    {
        public void InsertNewCategory(Category category);
        public List<Category> GetAllCategoriesFromDb();
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);
    }
}
