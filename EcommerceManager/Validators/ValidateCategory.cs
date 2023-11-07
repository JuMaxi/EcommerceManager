using EcommerceManager.Interfaces;
using EcommerceManager.Models.DataBase;

namespace EcommerceManager.Validators
{
    public class ValidateCategory : IValidateCategory
    {
        private readonly ICategoryDbAccess _categoryDbAccess;
        public ValidateCategory(ICategoryDbAccess categoryDbAccess)
        {
            _categoryDbAccess = categoryDbAccess;
        }

        public void Validate(Category category)
        {
            ValidateName(category.Name);
            ValidateDescription(category.Description);
            ValidateImage(category.Image);
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("The Name field must be filled to continue.");
            }
            if(_categoryDbAccess.GetCategoryFromDbByName(name) != null)
            {
                throw new Exception("This category Name " + name + " is already registered. Change the name to continue.");
            }
        }

        private void ValidateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("The Description field must be filled to continue");
            }
            if(_categoryDbAccess.GetCategoryFromDbByDescription(description) != null)
            {
                throw new Exception("The category Description " + description + " is already registered. Change the description to continue");
            }
        }
        static void ValidateImage(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                throw new Exception("The Image field must be filled to continue");
            }
        }
    }
}
