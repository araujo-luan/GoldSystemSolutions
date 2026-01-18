using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
    //Entidade de item do pedido, onde serão armazenadas as informações dos itens dos pedidos.
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

        public OrderItem(
            int orderId,
            int productId,
            int quantity,
            decimal unitPrice,
            decimal subTotalPrice,
            decimal discount,
            decimal totalPrice
            )
        {
            ValidationDomain(
                orderId,
                productId,
                quantity,
                unitPrice,
                subTotalPrice,
                discount,
                totalPrice
                );
        }

        public OrderItem(
            int id,
            int orderId,
            int productId,
            int quantity,
            decimal unitPrice,
            decimal subTotalPrice,
            decimal discount,
            decimal totalPrice
            )
        {
            DomainExceptionValidation.When(id <= 0,
                "Invalid Id. Id must be greater than zero.");
            Id = id;
            ValidationDomain(
                orderId,
                productId,
                quantity,
                unitPrice,
                subTotalPrice,
                discount,
                totalPrice
                );
        }

        public void Update(
            int orderId,
            int productId,
            int quantity,
            decimal unitPrice,
            decimal subTotalPrice,
            decimal discount,
            decimal totalPrice
            )
        {
            ValidationDomain(
                orderId,
                productId,
                quantity,
                unitPrice,
                subTotalPrice,
                discount,
                totalPrice
                );
        }

        public void ValidationDomain(
            int orderId,
            int productId,
            int quantity,
            decimal unitPrice,
            decimal subTotalPrice,
            decimal discount,
            decimal totalPrice
            )
        {
            DomainExceptionValidation.When(orderId <= 0,
                "Invalid Order Id. Order Id must be greater than zero.");
            DomainExceptionValidation.When(productId <= 0,
                "Invalid Product Id. Product Id must be greater than zero.");
            DomainExceptionValidation.When(quantity <= 0,
                "Invalid Quantity. Quantity must be greater than zero.");
            DomainExceptionValidation.When(unitPrice < 0,
                "Invalid Unit Price. Unit Price must be non-negative.");
            DomainExceptionValidation.When(subTotalPrice < 0,
                "Invalid SubTotal Price. SubTotal Price must be non-negative.");
            DomainExceptionValidation.When(discount < 0,
                "Invalid Discount. Discount must be non-negative.");
            DomainExceptionValidation.When(totalPrice < 0,
                "Invalid Total Price. Total Price must be non-negative.");
            DomainExceptionValidation.When(totalPrice != (subTotalPrice - discount),
                "Invalid Total Price. Total Price must be equal to SubTotal Price minus Discount.");
            DomainExceptionValidation.When(subTotalPrice != (quantity * unitPrice),
                "Invalid Sub Total Price. Sub Total Price must be equal to Quantity multiplied by Unit Price.");

            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            SubTotalPrice = subTotalPrice;
            Discount = discount;
            TotalPrice = totalPrice;
        }
    }
}
