using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{

    //Entidade de transportadora, onde serão armazenadas as informações das transportadoras.
    public sealed class Carrier
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string DocumentNumber { get; private set; } // CPF or CNPJ

        public ICollection<Address> Addresses { get; private set; } //PROPERTY NAVIGATION
        public Carrier(
            String name,
            String phone,
            String email,
            String documentNumber
            ) 
        {
            ValidationDomain(name,phone,email,documentNumber);
        }

        public Carrier(
            int id,
            String name,
            String phone,
            String email,
            String documentNumber
            ) 
        { 
            DomainExceptionValidation.When(Id < 0,
                "Invalid Id. Id must be greater than or equal to zero");
            Id = id;
            ValidationDomain(name, phone, email, documentNumber);

        }

        public void Update(
            String name,
            String phone,
            String email,
            String documentNumber
            )
        {
            ValidationDomain(name, phone, email, documentNumber);
        }

        private void ValidationDomain(
            String name,
            String phone,
            String email,
            String documentNumber
            )
        {
            //Validações das propriedades da entidade Carrier
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name. Name is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(phone),
                "Invalid Phone. Phone is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                "Invalid Email. Email is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(documentNumber),
                "Invalid Document Number. Document Number is required");
            DomainExceptionValidation.When(documentNumber.Length < 13,
                "Invalid Document Number. Document Number must be at least 13 characters long");
            DomainExceptionValidation.When(documentNumber.Length > 14,
                "Invalid Document Number. Document Number must be at most 14 characters long");
            DomainExceptionValidation.When(!documentNumber.All(char.IsDigit),
                "Invalid Document Number. Document Number must contain only digits");
            DomainExceptionValidation.When(!email.Contains("@"),
                "Invalid Email. Email must contain '@' symbol");
            DomainExceptionValidation.When(email.Contains(" "),
                "Invalid Email. Email must not contain spaces");
            DomainExceptionValidation.When(email.Contains(","),
                "Invalid Email. Email must not contain commas");
            DomainExceptionValidation.When(email.Contains(";"),
                "Invalid Email. Email must not contain semicolons");
            DomainExceptionValidation.When(email.Contains(":"),
                "Invalid Email. Email must not contain colons");
            DomainExceptionValidation.When(email.Contains("/"),
                "Invalid Email. Email must not contain slashes");
            DomainExceptionValidation.When(email.Contains("\\"),
                "Invalid Email. Email must not contain backslashes");
            DomainExceptionValidation.When(email.Contains("'"),
                "Invalid Email. Email must not contain apostrophes");
            DomainExceptionValidation.When(email.Contains("\""),
                "Invalid Email. Email must not contain quotation marks");
            DomainExceptionValidation.When(email.Contains("<") || email.Contains(">"),
                "Invalid Email. Email must not contain angle brackets");
            DomainExceptionValidation.When(email.Contains("@.") || email.Contains(".@"),
                "Invalid Email. Email must not have dot adjacent to '@' symbol");
            DomainExceptionValidation.When(email.Contains(".."),
                "Invalid Email. Email must not contain consecutive dots");
            DomainExceptionValidation.When(email.Contains("@@"),
                "Invalid Email. Email must not contain consecutive '@' symbols");

            //Atribuições se tudo estiver ok
            Name = name;
            Phone = phone;
            Email = email;
            DocumentNumber = documentNumber;
        }
    }
}
