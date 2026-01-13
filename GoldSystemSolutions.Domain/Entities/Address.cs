using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    public sealed class Address
    {
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

        public Address() { }
    }
}
