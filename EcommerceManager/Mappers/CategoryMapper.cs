using EcommerceManager.Interfaces;
using EcommerceManager.Models.DataBase;
using EcommerceManager.Models.Requests;

namespace EcommerceManager.Mappers
{
    public class CategoryMapper : ICategoryMapper
    {
        public Category ConvertCategoryRequestToCategory(CategoryRequest categoryRequest)
        {
            Category category = new Category()
            {
                Name = categoryRequest.Name,
                Description = categoryRequest.Description,
                Image = categoryRequest.Image,
                Parent = new()
                {
                    Id = categoryRequest.ParentId
                }
            };

            return category;
        }
    }
}
