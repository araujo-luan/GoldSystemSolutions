using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    public sealed class Order
    {
        public int Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Status { get; private set; }
        public int Balance { get; private set; }
        public int CustomerId { get; private set; } //FOREIGN KEY
        public Customer Customer { get; private set; } //PROPERTY NAVIGATION
        public required ICollection<OrderItem> OrderItems { get; set; } //PROPERTY NAVIGATION
        public Order() { }
    }
}
