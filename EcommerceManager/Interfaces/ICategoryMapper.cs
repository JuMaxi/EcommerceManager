using EcommerceManager.Models.DataBase;
using EcommerceManager.Models.Requests;

namespace EcommerceManager.Interfaces
{
    public interface ICategoryMapper
    {
        public Category ConvertCategoryRequestToCategory(CategoryRequest categoryRequest);
    }
}
