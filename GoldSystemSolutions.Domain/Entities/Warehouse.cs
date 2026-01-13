using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    public sealed class Warehouse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public string DocumentNumber { get; private set; } // CNPJ
        public ICollection<Address> Addresses { get; private set; } //PROPERTY NAVIGATION
        public Warehouse() { }
    }
}
