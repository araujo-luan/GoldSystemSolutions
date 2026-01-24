using FluentAssertions;
using GoldSystemSolutions.Domain.Entities;
using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Tests
{
    public class CarrierUnityTest
    {

        [Fact(DisplayName = "Create Carrier With Valid Parameters")]
        public void CreateCarrier_WithValidParameters_ShouldCreateCarrier()
        {
            Action action = () => new Carrier(
                "Transportadora Ltda",
                "+5511912880424",
                "administracao@transpltda.com",
                "12345678000195"
            );

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Carrier With Invalid Name")]
        public void CreateCarrier_WithInvalidName_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Carrier(
                "",
                "+5511912880424",
                "administracao@transpltda.com",
                "12345678000195"
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name. Name is required");
        }

        [Fact(DisplayName = "Create Carrier With Invalid Id")]
        public void CreateCarrier_WithInvalidId_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Carrier(
                -1,
                "Transportadora Ltda",
                "+5511912880424",
                "administracao@transpltda.com",
                "12345678000195"
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id must be greater than 0");
        }

    }
}
