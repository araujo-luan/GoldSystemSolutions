using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{

    //Entidade de armazém, onde serão armazenadas as informações dos armazéns.
    public sealed class Warehouse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public string DocumentNumber { get; private set; } // CNPJ
        public ICollection<Address> Addresses { get; private set; } //PROPERTY NAVIGATION
        
        public Warehouse(
            string name,
            int capacity,
            string documentNumber
            )
        {
            ValidationDomain(name, capacity, documentNumber);
        }

        public Warehouse(
            int id,
            string name,
            int capacity,
            string documentNumber
            )
        {
            DomainExceptionValidation.When(id <= 0,
                "Invalid Id. Id must be greater than zero.");
            Id = id;
            ValidationDomain(name, capacity, documentNumber);
        }

        public void Update(
            string name,
            int capacity,
            string documentNumber
            )
        {
            ValidationDomain(name, capacity, documentNumber);
        }

        public void ValidationDomain(
            string name,
            int capacity,
            string documentNumber
            )
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");
            DomainExceptionValidation.When(capacity <= 0,
                "Invalid capacity. Capacity must be greater than zero");
            DomainExceptionValidation.When(string.IsNullOrEmpty(documentNumber),
                "Invalid document number. Document number is required");
            DomainExceptionValidation.When(documentNumber.Length > 14,
                "Invalid document number. Document number must not exceed 14 characters");
            DomainExceptionValidation.When(documentNumber.Length < 11,
                "Invalid document number. Document number must be 11 characters");
            DomainExceptionValidation.When(name.Length > 100,
                "Invalid name, too long, maximum 100 characters");
            
            Name = name;
            Capacity = capacity;
            DocumentNumber = documentNumber;
        }
    }
}
