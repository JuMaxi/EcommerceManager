using EcommerceManager.Interfaces;
using EcommerceManager.Models.DataBase;
using EcommerceManager.Models.Requests;
using EcommerceManager.Models.Responses;

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
        public List<CategoryResponse> ConvertCategoryToCategoryResponse(List<Category> list)
        {
            List<CategoryResponse> listCategoriesResponse = new();
            foreach(Category c in list)
            {
                CategoryResponse categoryResponse = new()
                {
                    Name = c.Name,
                    Description = c.Description,
                    Image = c.Image,
                    ParentName = c.Parent.Name,
                    ParentId = c.Parent.Id
                };
                listCategoriesResponse.Add(categoryResponse);
            }
            return listCategoriesResponse;
        }
    }
}
