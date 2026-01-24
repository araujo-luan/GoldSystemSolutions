using FluentAssertions;
using GoldSystemSolutions.Domain.Entities;
using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Tests
{
    public class CategoryUnityTest1
    {

        [Fact(DisplayName = "Create Category With Valid Parameters")]
        public void CreateCategory_WithValidParameters_ShouldCreateCategory()
        {
            Action action = () => new Category(
                "Eletrônicos",
                "Categoria de produtos eletrônicos"
            );
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Invalid Name")]
        public void CreateCategory_WithInvalidName_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Category(
                "",
                "Categoria de produtos eletrônicos"
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name. Name is required");
        }

        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_WithInvalidId_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Category(
                -1,
                "Eletrônicos",
                "Categoria de produtos eletrônicos"
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id must be greater than or equal to zero");
        }

        [Fact(DisplayName = "Create Category With Short Description")]
        public void CreateCategory_WithShortDescription_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Category(
                "Eletrônicos",
                "Cat"
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Category With Long Name")]
        public void CreateCategory_WithLongName_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Category(
                new string('A', 101),
                "Categoria de produtos eletrônicos"
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, too long, maximum 100 characters");
        }

        [Fact(DisplayName = "Create Category With Long Description")]
        public void CreateCategory_WithLongDescription_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Category(
                "Eletrônicos",
                new string('B', 201)
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, too long, maximum 200 characters");
        }

        [Fact(DisplayName = "Create Category With Empty Description")]
        public void CreateCategory_WithEmptyDescription_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Category(
                "Eletrônicos",
                ""
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description. Description is required");
        }

        [Fact(DisplayName = "Create Category With Null Description")]
        public void CreateCategory_WithNullDescription_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Category(
                "Eletrônicos",
                null
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description. Description is required");
        }

        [Fact(DisplayName = "Create Category With Null Name")]
        public void CreateCategory_WithNullName_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Category(
                null,
                "Categoria de produtos eletrônicos"
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name. Name is required");
        }

    }
}
