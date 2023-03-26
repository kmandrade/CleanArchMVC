using Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateCategory_WithValidNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>();
        }
    }
}
