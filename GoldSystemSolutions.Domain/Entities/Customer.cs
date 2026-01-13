using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    public sealed class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string DocumentNumber {  get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        
        public required ICollection<Address> Addresses { get; set; } //PROPERTY NAVIGATION
    }
}
