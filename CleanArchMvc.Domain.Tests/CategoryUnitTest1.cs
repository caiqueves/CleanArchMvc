using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category with Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category with Invalid State")]
        public void CreateCategory_NegativeIdValue_ResultObjectValidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }
    }
}
