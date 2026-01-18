using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    //Entidade de endereço, onde serão armazenados os endereços de clientes, transportadoras e armazéns.
    public sealed class Address
    {
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public int Type { get; private set; } // e.g., 0 = Principal, 1 = Outros endereços

        public int CustomerId { get; private set; } //FOREIGN KEY
        public Customer Customer { get; private set; } //PROPERTY NAVIGATION

        public int CarrierId { get; private set; } //FOREIGN KEY
        public Carrier Carrier { get; private set; } //PROPERTY NAVIGATION

        public int WarehouseId { get; private set; } //FOREIGN KEY
        public Warehouse Warehouse { get; private set; } //PROPERTY NAVIGATION

        public ICollection<Invoce> Invoces { get; private set; } //PROPERTY NAVIGATION

        public Address(
            String street, 
            String number, 
            String complement, 
            String city, 
            String state, 
            String zipCode, 
            String country, 
            int type
            ) 
        { 
            ValidationDomain(
                street,
                number,
                complement,
                city,
                state,
                zipCode,
                country,
                type
                );
        }

        public Address(
            int id,
            String street,
            String number,
            String complement,
            String city,
            String state,
            String zipCode,
            String country,
            int type
            )
        {
            DomainExceptionValidation.When(id < 0,
                "Invalid Id");
            Id = id;
            ValidationDomain(street, number, complement, city, state, zipCode, country, type);
        }

        public void Update(
            String street,
            String number,
            String complement,
            String city,
            String state,
            String zipCode,
            String country,
            int type
            )
        {
            ValidationDomain(
                street,
                number,
                complement,
                city,
                state,
                zipCode,
                country,
                type
                );
        }

        public void AssignCustomer(int customerId)
        {
            DomainExceptionValidation.When(customerId < 0,
                "Invalid Customer Id");
            CustomerId = customerId;
        }

        public void AssignCarrier(int carrierId)
        {
            DomainExceptionValidation.When(carrierId < 0,
                "Invalid Carrier Id");
            CarrierId = carrierId;
        }

        public void AssignWarehouse(int warehouseId)
        {
            DomainExceptionValidation.When(warehouseId < 0,
                "Invalid Warehouse Id");
            WarehouseId = warehouseId;
        }

        public void UnassignCustomer()
        {
            CustomerId = 0;
        }

        public void UnassignCarrier()
        {
            CarrierId = 0;
        }

        public void UnassignWarehouse()
        {
            WarehouseId = 0;
        }


        //Método para validar as propriedades da entidade Address
        private void ValidationDomain(
            String street,
            String number,
            String complement,
            String city,
            String state,
            String zipCode,
            String country,
            int type
            )
        {
            //Validações das propriedades da entidade Address
            DomainExceptionValidation.When(string.IsNullOrEmpty(street),
                "Street is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(number),
                "Number is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(city),
                "City is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(state),
                "State is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(zipCode),
                "ZipCode is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(country),
                "Country is required");
            DomainExceptionValidation.When(type < 0,
                "Type is required");
            DomainExceptionValidation.When(type > 1,
                "Type invalid");
            DomainExceptionValidation.When(zipCode.Length != 8,
                "ZipCode must have 8 characters");
            DomainExceptionValidation.When(state.Length != 2,
                "State must have 2 characters");
            DomainExceptionValidation.When(street.Length > 150,
                "Street must have a maximum of 150 characters");
            DomainExceptionValidation.When(number.Length > 20,
                "Number must have a maximum of 20 characters");
            DomainExceptionValidation.When(complement.Length > 80,
                "Complement must have a maximum of 80 characters");
            DomainExceptionValidation.When(city.Length > 100,
                "City must have a maximum of 100 characters");
            DomainExceptionValidation.When(country.Length > 100,
                "Country must have a maximum of 100 characters");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(zipCode),
                "ZipCode cannot be whitespace");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(state),
                "State cannot be whitespace");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(number),
                "Number cannot be whitespace");

            //Atribuição dos valores às propriedades da entidade Address
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Type = type;

        }
    }
}
