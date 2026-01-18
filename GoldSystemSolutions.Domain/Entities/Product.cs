using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{

    //Entidade de produto, onde serão armazenadas as informações dos produtos.
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

        public Product(
            string name,
            string description,
            decimal price,
            int stockQuantity,
            string sku,
            string imageUrl,
            int categoryId
            )
        {
            ValidationDomain(
                name,
                description,
                price,
                stockQuantity,
                sku,
                imageUrl,
                categoryId
                );
        }

        public Product(
            int id,
            string name,
            string description,
            decimal price,
            int stockQuantity,
            string sku,
            string imageUrl,
            int categoryId
            )
        {
            DomainExceptionValidation.When(id < 0,
                "Invalid Id value");
            Id = id;
            ValidationDomain(
                name,
                description,
                price,
                stockQuantity,
                sku,
                imageUrl,
                categoryId
                );
        }

        public void Update(
            string name,
            string description,
            decimal price,
            int stockQuantity,
            string sku,
            string imageUrl,
            int categoryId
            )
        {
            ValidationDomain(
                name,
                description,
                price,
                stockQuantity,
                sku,
                imageUrl,
                categoryId
                );
        }

        public void ValidationDomain(
            string name,
            string description,
            decimal price,
            int stockQuantity,
            string sku,
            string imageUrl,
            int categoryId
            )
        {
            //Validações dos campos da entidade Product
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Name is required");
            DomainExceptionValidation.When(price < 0,
                "Price cannot be negative");
            DomainExceptionValidation.When(stockQuantity < 0,
                "Stock Quantity cannot be negative");
            DomainExceptionValidation.When(categoryId <= 0,
                "Category ID must be greater than zero");
            DomainExceptionValidation.When(string.IsNullOrEmpty(sku),
                "SKU is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Description is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(imageUrl),
                "Image URL is required");
            DomainExceptionValidation.When(description.Length < 10,
                "Description must be at least 10 characters long");
            DomainExceptionValidation.When(description.Length > 1000,
                "Description cannot exceed 1000 characters");
            DomainExceptionValidation.When(imageUrl.Length > 250,
                "Image URL cannot exceed 250 characters");
            DomainExceptionValidation.When(imageUrl.Length < 5,
                "Image URL must be at least 5 characters long");
            DomainExceptionValidation.When(name.Length < 3,
                "Name must be at least 3 characters long");


            //Atribuição dos valores às propriedades da entidade Product
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            SKU = sku;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
        }
    }
}
