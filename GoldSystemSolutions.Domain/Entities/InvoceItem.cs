using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    public sealed class InvoceItem
    {
        public int Id { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal Weight { get; private set; } //PESO UNITÁRIO DO ITEM NA NF
        public decimal TotalWeight { get; private set; } //PESO TOTAL DO ITEM NA NF
        public int ProductId { get; private set; } //FOREIGN KEY
        public Product Product { get; private set; } //PROPERTY NAVIGATION
        public int InvoceId { get; private set; } //FOREIGN KEY
        public Invoce Invoce { get; private set; } //PROPERTY NAVIGATION
        public int OrderItemId { get; private set; } //FOREIGN KEY
        public OrderItem OrderItem { get; private set; } //PROPERTY NAVIGATION
    }
}
