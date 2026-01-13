using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    public sealed class Carrier
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string DocumentNumber { get; private set; } // CPF or CNPJ

        public ICollection<Address> Addresses { get; private set; } //PROPERTY NAVIGATION
        public Carrier() { }
    }
}
