using EcommerceManager.Interfaces;
using EcommerceManager.Models.DataBase;
using EcommerceManager.Validators;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceManager.Tests.Validators
{
    public class ValidateCategoryTests
    {
        [Fact]
        public void When_name_is_null_should_throw_new_exception()
        {
            Category category = new() { Name = null };

            ValidateCategory validatorCategory = new(null);

            validatorCategory.Invoking(validator => validator.Validate(category))
            .Should().Throw<Exception>()
            .WithMessage("The Name field must be filled to continue.");
        }

        [Fact]
        public void When_name_length_is_zero_should_throw_new_exception()
        {
            Category category = new() { Name = "" };

            ValidateCategory validatorCategory = new(null);

            validatorCategory.Invoking(validator => validator.Validate(category))
                .Should().Throw<Exception>()
                .WithMessage("The Name field must be filled to continue.");
        }

        [Fact]
        public void When_name_is_already_registered_into_database_should_throw_new_exception()
        {
            Category category = new() { Name = "Trousers" };
            Category category2 = new() { Name = "Trousers" };

            var dbAccessCategoryFake = Substitute.For<ICategoryDbAccess>();
            dbAccessCategoryFake.GetCategoryFromDbByName(category2.Name).Returns(category2);

            ValidateCategory validatorCategory = new(dbAccessCategoryFake);

            validatorCategory.Invoking(validator => validator.Validate(category))
                .Should().Throw<Exception>()
                .WithMessage("This category Name " + category2.Name + " is already registered. Change the name to continue.");
        }

        [Fact]
        public void When_description_is_null_should_throw_new_exception()
        {
            Category category = new()
            {
                Name = "Trousers",
                Description = null
            };

            Category category2 = new()
            {
                Name = "Skirt"
            };

            var dbAccessCategoryFake = Substitute.For<ICategoryDbAccess>();
            dbAccessCategoryFake.GetCategoryFromDbByName(category2.Name).Returns(category2);   

            ValidateCategory validatorCategory = new(dbAccessCategoryFake);

            validatorCategory.Invoking(validator => validator.Validate(category))
                .Should().Throw<Exception>()
                .WithMessage("The Description field must be filled to continue");
        }

        [Fact]
        public void When_description_length_is_zero_should_throw_new_exception()
        {
            Category category = new()
            {
                Name = "Trousers",
                Description = ""
            };

            Category category2 = new()
            {
                Name = "Skirt"
            };

            var dbAccessCategoryFake = Substitute.For<ICategoryDbAccess>();
            dbAccessCategoryFake.GetCategoryFromDbByName(category2.Name).Returns(category2);

            ValidateCategory validatorCategory = new(dbAccessCategoryFake);

            validatorCategory.Invoking(validator => validator.Validate(category))
                .Should().Throw<Exception>()
                .WithMessage("The Description field must be filled to continue");
        }

        [Fact]
        public void When_description_is_already_registered_into_database_should_throw_new_exception()
        {
            Category category = new()
            {
                Name = "Trousers",
                Description = "Women Trousers"
            };

            Category category2 = new()
            {
                Name = "Skirts",
                Description = "Women Trousers"
            };

            var dbAccessCategoryFake = Substitute.For<ICategoryDbAccess>();
            dbAccessCategoryFake.GetCategoryFromDbByDescription(category2.Description).Returns(category2);

            ValidateCategory validatorCategory = new(dbAccessCategoryFake);

            validatorCategory.Invoking(validator => validator.Validate(category))
                .Should().Throw<Exception>()
                .WithMessage("The category Description " + category.Description + " is already registered. Change the description to continue");
        }

        [Fact]
        public void When_image_is_null_should_throw_new_exception()
        {
            Category category = new()
            {
                Name = "Trousers",
                Description = "Women Trousers",
                Image = null
            };

            Category category2 = new()
            {
                Id = 1,
                Name = "Skirt",
                Description = "Women Skirts"
            };

            var dbAccessCategoryFake = Substitute.For<ICategoryDbAccess>();
            dbAccessCategoryFake.GetCategoryFromDbById(category2.Id).Returns(category2);

            ValidateCategory validatorCategory = new(dbAccessCategoryFake);

            validatorCategory.Invoking(validator => validator.Validate(category))
                .Should().Throw<Exception>()
                .WithMessage("The Image field must be filled to continue");
        }

        [Fact]
        public void When_image_length_is_zero_should_throw_new_exception()
        {
            Category category = new()
            {
                Name = "Trousers",
                Description = "Women Trousers",
                Image = ""
            };

            Category category2 = new()
            {
                Id = 1,
                Name = "Skirt",
                Description = "Women Skirts"
            };

            var dbAccessCategoryFake = Substitute.For<ICategoryDbAccess>();
            dbAccessCategoryFake.GetCategoryFromDbById(category2.Id).Returns(category2);

            ValidateCategory validatorCategory = new(dbAccessCategoryFake);

            validatorCategory.Invoking(validator => validator.Validate(category))
                .Should().Throw<Exception>()
                .WithMessage("The Image field must be filled to continue");
        }
    }
}
