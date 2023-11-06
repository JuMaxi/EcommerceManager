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
    }
}
