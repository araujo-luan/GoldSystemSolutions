using FluentAssertions;
using GoldSystemSolutions.Domain.Entities;
using GoldSystemSolutions.Domain.Validation;

namespace GoldSystemSolutions.Domain.Tests
{
    public class AddressUnityTest1
    {
        [Fact(DisplayName = "Create Address With Valid State")]
        public void CreateAddress_WithValidParameters_ReusltSuccess()
        {

            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                0
            );

            action.Should()
                .NotThrow<DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Create Address With Invalid State")]
        public void CreateAddress_WithInvalidState_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                "SaoPaulo",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("State must have 2 characters");
        }

        [Fact(DisplayName = "Create Address With Invalid ZipCode")]
        public void CreateAddress_WithInvalidZipCode_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("ZipCode must have 8 characters");
        }

        [Fact(DisplayName = "Create Address With Empty Street")]
        public void CreateAddress_WithEmptyStreet_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "",
                "1000",
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Street is required");
        }

        [Fact(DisplayName = "Create Address With Invalid Type")]
        public void CreateAddress_WithInvalidType_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                3
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Type invalid");
        }

        [Fact(DisplayName = "Create Address With Null Number")]
        public void CreateAddress_WithNullNumber_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                null,
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Number is required");
        }

        [Fact(DisplayName = "Create Address With Null Country")]
        public void CreateAddress_WithNullCountry_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310-100",
                null,
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Country is required");
        }

        [Fact(DisplayName = "Create Address With Null City")]
        public void CreateAddress_WithNullCity_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                null,
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("City is required");
        }

        [Fact(DisplayName = "Create Address With Null State")]
        public void CreateAddress_WithNullState_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                null,
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("State is required");
        }

        [Fact(DisplayName = "Create Address With Null ZipCode")]
        public void CreateAddress_WithNullZipCode_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                "SP",
                null,
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("ZipCode is required");
        }

        [Fact(DisplayName = "Create Address With Null Complement")]
        public void CreateAddress_WithNullComplement_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                null,
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Address With Empty Country")]
        public void CreateAddress_WithEmptyCountry_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310-100",
                "",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Country is required");

        }

        [Fact(DisplayName = "Create Address With Empty City")]
        public void CreateAddress_WithEmptyCity_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "",
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("City is required");
        }

        [Fact(DisplayName = "Create Address With Empty State")]
        public void CreateAddress_WithEmptyState_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                "",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("State is required");
        }

        [Fact(DisplayName = "Create Address With Empty ZipCode")]
        public void CreateAddress_WithEmptyZipCode_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                "São Paulo",
                "SP",
                "",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("ZipCode is required");
        }

        [Fact(DisplayName = "Create Address With Empty Complement")]
        public void CreateAddress_WithEmptyComplement_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "",
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Address With Empty Number")]
        public void CreateAddress_WithEmptyNumber_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Address(
                "Av. Paulista",
                "",
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Number is required");
        }

        [Fact(DisplayName = "Create Address With Street Exceeding Max Length")]
        public void CreateAddress_WithStreetExceedingMaxLength_ThrowsDomainExceptionValidation()
        {
            string longStreet = new string('A', 151); // 151 characters
            Action action = () => new Address(
                longStreet,
                "1000",
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Street must have a maximum of 150 characters");
        }

        [Fact(DisplayName = "Create Address With Number Exceeding Max Length")]
        public void CreateAddress_WithNumberExceedingMaxLength_ThrowsDomainExceptionValidation()
        {
            string longNumber = new string('1', 21); // 21 characters
            Action action = () => new Address(
                "Av. Paulista",
                longNumber,
                "Bela Vista",
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Number must have a maximum of 20 characters");
        }

        [Fact(DisplayName = "Create Address With Complement Exceeding Max Length")]
        public void CreateAddress_WithComplementExceedingMaxLength_ThrowsDomainExceptionValidation()
        {
            string longComplement = new string('C', 81); // 81 characters
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                longComplement,
                "São Paulo",
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Complement must have a maximum of 80 characters");
        }

        [Fact(DisplayName = "Create Address With City Exceeding Max Length")]
        public void CreateAddress_WithCityExceedingMaxLength_ThrowsDomainExceptionValidation()
        {
            string longCity = new string('C', 101); // 101 characters
            Action action = () => new Address(
                "Av. Paulista",
                "1000",
                "Bela Vista",
                longCity,
                "SP",
                "01310-100",
                "Brasil",
                0
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("City must have a maximum of 100 characters");
        }



    }

}
