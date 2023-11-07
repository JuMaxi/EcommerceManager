using EcommerceManager.Mappers;
using EcommerceManager.Models.DataBase;
using EcommerceManager.Models.Requests;
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
    }
}
