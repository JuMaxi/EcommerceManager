﻿using EcommerceManager.Interfaces;
using EcommerceManager.Models.DataBase;
using EcommerceManager.Models.Requests;
using EcommerceManager.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceManager.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _categoryService;
        readonly ICategoryMapper _categoryMapper;

        public CategoryController(ICategoryService categoryService, ICategoryMapper categoryMapper)
        {
            _categoryService = categoryService;
            _categoryMapper = categoryMapper;
        }

        [HttpPost]
        public void AddNewCategory(CategoryRequest categoryRequest)
        {
            Category category = _categoryMapper.ConvertCategoryRequestToCategory(categoryRequest);
            _categoryService.InsertNewCategory(category);
        }

        [HttpGet]
        public List<CategoryResponse> GetCategoriesFromDb()
        {
            List<Category> categories = _categoryService.GetAllCategoriesFromDb();

            List<CategoryResponse> listCategoriesResponse = _categoryMapper.ConvertCategoryToCategoryResponse(categories);

            return listCategoriesResponse;
        }

        [HttpPut("{id}")]
        public void UpdateCategory([FromRoute] int id, [FromBody] CategoryRequest categoryRequest)
        {
            Category category = _categoryMapper.ConvertCategoryRequestToCategory(categoryRequest);
            category.Id = id;

            _categoryService.UpdateCategory(category);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory([FromRoute] int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
