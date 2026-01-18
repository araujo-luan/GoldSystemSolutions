using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{

    //Entidade de item da nota fiscal, onde serão armazenadas as informações dos itens das notas fiscais.
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

        public InvoceItem(
            decimal quantity,
            decimal unitPrice,
            decimal totalPrice,
            decimal weight,
            decimal totalWeight,
            int productId,
            int invoceId,
            int orderItemId
            )
        {
            ValidationDomain(
                quantity,
                unitPrice,
                totalPrice,
                weight,
                totalWeight,
                productId,
                invoceId,
                orderItemId
                );
        }

        public InvoceItem(
            int id,
            decimal quantity,
            decimal unitPrice,
            decimal totalPrice,
            decimal weight,
            decimal totalWeight,
            int productId,
            int invoceId,
            int orderItemId
            )
        { 
            DomainExceptionValidation.When(id <= 0,
                "Invalid Id. Id must be greater than zero");
            Id = id;
            ValidationDomain(
                quantity,
                unitPrice,
                totalPrice,
                weight,
                totalWeight,
                productId,
                invoceId,
                orderItemId
                );
        }

        public void Update(
            decimal quantity,
            decimal unitPrice,
            decimal totalPrice,
            decimal weight,
            decimal totalWeight,
            int productId,
            int invoceId,
            int orderItemId
            )
        {
            ValidationDomain(
                quantity,
                unitPrice,
                totalPrice,
                weight,
                totalWeight,
                productId,
                invoceId,
                orderItemId
                );
        }
        public void ValidationDomain(
            decimal quantity,
            decimal unitPrice,
            decimal totalPrice,
            decimal weight,
            decimal totalWeight,
            int productId,
            int invoceId,
            int orderItemId
            )
        {
            //Adicione as validações necessárias aqui, se houver.

            DomainExceptionValidation.When(quantity <= 0,
                "Invalid Quantity. Quantity must be greater than zero");
            DomainExceptionValidation.When(unitPrice < 0,
                "Invalid Unit Price. Unit Price cannot be negative");
            DomainExceptionValidation.When(totalPrice < 0,
                "Invalid Total Price. Total Price cannot be negative");
            DomainExceptionValidation.When(weight < 0,
                "Invalid Weight. Weight cannot be negative");
            DomainExceptionValidation.When(totalWeight < 0,
                "Invalid Total Weight. Total Weight cannot be negative");
            DomainExceptionValidation.When(productId <= 0,
                "Invalid Product ID. Product ID must be greater than zero");
            DomainExceptionValidation.When(invoceId <= 0,
                "Invalid Invoce ID. Invoce ID must be greater than zero");
            DomainExceptionValidation.When(orderItemId <= 0,
                "Invalid Order Item ID. Order Item ID must be greater than zero");
            DomainExceptionValidation.When(totalPrice != quantity * unitPrice,
                "Invalid Total Price. Total Price must be equal to Quantity multiplied by Unit Price");
            DomainExceptionValidation.When(totalWeight != quantity * weight,
                "Invalid Total Weight. Total Weight must be equal to Quantity multiplied by Weight");

            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
            Weight = weight;
            TotalWeight = totalWeight;
            ProductId = productId;
            InvoceId = invoceId;
            OrderItemId = orderItemId;
        }
    }
}
