using EcommerceManager.Db;
using EcommerceManager.Interfaces;
using EcommerceManager.Models.DataBase;

namespace EcommerceManager.DbAccess
{
    public class CategoryDbAccess : ICategoryDbAccess
    {
        private readonly EcommerceManagerDbContext _dbContext;

        public CategoryDbAccess(EcommerceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNewCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public Category GetCategoryFromDbById(int id)
        {
            return _dbContext.Categories.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public Category GetCategoryFromDbByName(string name)
        {
            return _dbContext.Categories.Where(c => c.Name.Equals(name)).FirstOrDefault();
        }

        public Category GetCategoryFromDbByDescription(string description)
        {
            return _dbContext.Categories.Where(c => c.Description.Equals(description)).FirstOrDefault();
        }
    }
}
