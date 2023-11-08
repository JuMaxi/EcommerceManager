using EcommerceManager.Models.DataBase;

namespace EcommerceManager.Interfaces
{
    public interface ICategoryDbAccess
    {
        public void AddNewCategory(Category category);
        public Category GetCategoryFromDbById(int id);
        public Category GetCategoryFromDbByName(string name);
        public Category GetCategoryFromDbByDescription(string description);
        public List<Category> GetListCategoriesFromDb();
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);
    }
}
