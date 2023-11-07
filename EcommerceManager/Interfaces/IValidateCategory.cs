using EcommerceManager.Models.DataBase;

namespace EcommerceManager.Interfaces
{
    public interface IValidateCategory
    {
        public void Validate(CategoryRequest category);
    }
}
