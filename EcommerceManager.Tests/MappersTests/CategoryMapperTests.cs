﻿using EcommerceManager.Mappers;
using EcommerceManager.Models.DataBase;
using EcommerceManager.Models.Requests;
using EcommerceManager.Models.Responses;
using FluentAssertions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceManager.Tests.MappersTests
{
    public class CategoryMapperTests
    {
        [Fact]
        public void Checking_If_CategoryRequest_is_Equal_Category()
        {
            CategoryRequest categoryRequest = new()
            {
                Name = "Trousers",
                Description = "Women Trousers",
                Image = "https:myclothes.co.uk/Trousers-Tailored-Business-Straight-Everpress",
                ParentId = 3,
            };

            CategoryMapper categoryMapper = new();
            Category category = categoryMapper.ConvertCategoryRequestToCategory(categoryRequest);

            category.Name.Should().Be(categoryRequest.Name);
            category.Description.Should().Be(categoryRequest.Description);
            category.Image.Should().Be(categoryRequest.Image);
            category.Parent.Id.Should().Be(categoryRequest.ParentId);
        }

        [Fact]
        public void Checking_If_Category_is_Equal_CategoryResponse()
        {
           
            Category category = new()
            {
                Name = "Trousers",
                Description = "Women Trousers",
                Image = "https:myclothes.co.uk/Trousers-Tailored-Business-Straight-Everpress",
                Parent = new()
                {
                    Id = 3,
                    Name = "Trousers"
                }
            };

            List<Category> categories = new() { { category } };

            CategoryMapper categoryMapper = new();
            List<CategoryResponse> listCategoriesResponse = categoryMapper.ConvertCategoryToCategoryResponse(categories);

            listCategoriesResponse[0].Name.Should().Be(category.Name);
            listCategoriesResponse[0].Description.Should().Be(category.Description);
            listCategoriesResponse[0].Image.Should().Be(category.Image);
            listCategoriesResponse[0].ParentName.Should().Be(category.Parent.Name);
            listCategoriesResponse[0].ParentId.Should().Be(category.Parent.Id);
           
        }
    }
}
