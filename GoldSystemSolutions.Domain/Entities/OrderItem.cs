using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    public sealed class OrderItem
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; } //FOREIGN KEY
        public Order Order { get; private set; } //PROPERTY NAVIGATION
        public int ProductId { get; private set; } //FOREIGN KEY
        public Product Product { get; private set; } //PROPERTY NAVIGATION
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal SubTotalPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice { get; private set; }
        public OrderItem() { }
    }
}
