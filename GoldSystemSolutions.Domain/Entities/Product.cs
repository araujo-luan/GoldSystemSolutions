using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public string SKU { get; private set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; private set; } //FOREIGN KEY
        public Category Category { get; private set; } //PROPERTY NAVIGATION
        public Product() { }
    }
}
