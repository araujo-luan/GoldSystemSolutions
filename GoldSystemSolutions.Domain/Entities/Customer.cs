using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{

    //Entidade de cliente, onde serão armazenadas as informações dos clientes.
    public sealed class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string DocumentNumber {  get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        
        public required ICollection<Address> Addresses { get; set; } //PROPERTY NAVIGATION

        public Customer(
            string name,
            string documentNumber,
            string email,
            string phoneNumber
            )
        {
            ValidationDomain(
                name,
                documentNumber,
                email,
                phoneNumber
                );
        }

        public Customer(int id,
            string name,
            string documentNumber,
            string email,
            string phoneNumber
            )
        {
            DomainExceptionValidation.When(id < 0,
                "Invalid Id. Id must be greater than zero");
            Id = id;
            ValidationDomain(
                name,
                documentNumber,
                email,
                phoneNumber
                );
        }

        public void Update(
            string name,
            string documentNumber,
            string email,
            string phoneNumber
            )
        {
            ValidationDomain(
                name,
                documentNumber,
                email,
                phoneNumber
                );
        }
        private void ValidationDomain(
            String name,
            String documentNumber,
            String email,
            String phoneNumber
            )
        {
            //Validações das propriedades da entidade Customer
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name. Name is required");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(documentNumber),
                "Invalid Document Number. Document Number is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                "Invalid Email. Email is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber),
                "Invalid Phone Number. Phone Number is required");
            DomainExceptionValidation.When(phoneNumber.Length < 8,
                "Invalid Phone Number, too short, minimum 8 characters");
            DomainExceptionValidation.When(phoneNumber.Length > 15,
                "Invalid Phone Number, too long, maximum 15 characters");
            DomainExceptionValidation.When(phoneNumber.StartsWith("0"),
                "Invalid Phone Number, cannot start with zero");
            DomainExceptionValidation.When(phoneNumber.Contains(" "),
                "Invalid Phone Number, cannot contain spaces");
            DomainExceptionValidation.When(phoneNumber.Any(c => !char.IsDigit(c)),
                "Invalid Phone Number, only numeric characters are allowed");
            DomainExceptionValidation.When(phoneNumber.Contains("-"),
                "Invalid Phone Number, cannot contain hyphens");
            DomainExceptionValidation.When(phoneNumber.Contains("(") || phoneNumber.Contains(")"),
                "Invalid Phone Number, cannot contain parentheses");
            Name = name;
            DocumentNumber = documentNumber;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
