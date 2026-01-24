using FluentAssertions;
using GoldSystemSolutions.Domain.Entities;
using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Tests
{
    public class CostomerUnityTest1
    {

        [Fact(DisplayName = "Create Customer With Valid Parameters")]
        public void CreateCustomer_WithValidParameters_ShouldCreateCustomer()
        {
            Action action = () => new Customer(
                "Mercado Da Eskina",
                "12345678901",
                "administracao@mercadodaeskina.com",
                "+551194586514"
            );

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Customer With Invalid Name")]
        public void CreateCustomer_WithInvalidName_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Customer(
                "",
                "12345678901",
                "administracao@mercadodaeskina.com",
                "+551194586514"
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name. Name is required");

        }

        [Fact(DisplayName = "Create Customer With Invalid Id")]
        public void CreateCustomer_WithInvalidId_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Customer(
                -1,
                "Mercado Da Eskina",
                "12345678901",
                "administracao@mercadodaeskina.com",
                "+551194586514"
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id must be greater than zero");
        }

        [Fact(DisplayName = "Create Customer With Short Name")]
        public void CreateCustomer_WithShortName_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Customer(
                "Me",
                "12345678901",
                "administracao@mercadodaeskina.com",
                "+551194586514"
            );

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name. Name must have at least 3 characters");
        }

        [Fact(DisplayName = "Create Customer With Invalid Document Number")]
        public void CreateCustomer_WithInvalidDocumentNumber_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Customer(
                "Mercado Da Eskina",
                "",
                "administracao@mercadodaeskina.com",
                "+551194586514"
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Document Number. Document Number is required");
        }

        [Fact(DisplayName = "Create Customer With Invalid Email")]
        public void CreateCustomer_WithInvalidEmail_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Customer(
                "Mercado Da Eskina",
                "12345678901",
                "",
                "+551194586514"
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Email. Email is required");
        }

        [Fact(DisplayName = "Create Customer With Invalid Phone Number")]
        public void CreateCustomer_WithInvalidPhoneNumber_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Customer(
                "Mercado Da Eskina",
                "12345678901",
                "administracao@mercadodaeskina.com",
                ""
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Phone Number. Phone Number is required");
        }

    }
}
