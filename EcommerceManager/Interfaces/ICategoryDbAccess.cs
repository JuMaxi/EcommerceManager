using EcommerceManager.Models.DataBase;

namespace EcommerceManager.Interfaces
{
    public interface ICategoryDbAccess
    {
        public void AddNewCategory(CategoryRequest category);
        public CategoryRequest GetCategoryFromDbById(int id);
        public CategoryRequest GetCategoryFromDbByName(string name);
        public CategoryRequest GetCategoryFromDbByDescription(string description);
    }
}
