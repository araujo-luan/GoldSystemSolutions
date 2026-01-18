using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{

    //Entidade de pedido, onde serão armazenadas as informações dos pedidos.
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
        
        public Order(
            DateTime orderDate,
            decimal totalAmount,
            string status,
            int balance,
            int customerId
            )
        {
            ValidationDomain(
                orderDate,
                totalAmount,
                status,
                balance,
                customerId
                );
        }

        public Order(
            int id,
            DateTime orderDate,
            decimal totalAmount,
            string status,
            int balance,
            int customerId
            )
        {
            DomainExceptionValidation.When(id <= 0,
                "Invalid Id. Id must be greater than zero.");
            Id = id;
            ValidationDomain(
                orderDate,
                totalAmount,
                status,
                balance,
                customerId
                );
        }

        public void Update(
            DateTime orderDate,
            decimal totalAmount,
            string status,
            int balance,
            int customerId
            )
        {
            ValidationDomain(
                orderDate,
                totalAmount,
                status,
                balance,
                customerId
                );
        }

        public void UpdateStatus(string status)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(status),
                "Status is required");
            Status = status;
        } 

        public void UpdateBalance(int balance)
        {
            DomainExceptionValidation.When(balance < 0,
                "Balance cannot be negative");
            Balance = balance;
        }

        public void UpdateTotalAmount(decimal totalAmount)
        {
            DomainExceptionValidation.When(totalAmount < 0,
                "Total amount cannot be negative");
            TotalAmount = totalAmount;
        }

        public void UpdateCustomerId(int customerId)
        {
            DomainExceptionValidation.When(customerId <= 0,
                "CustomerId must be greater than zero");
            CustomerId = customerId;
        }

        public void ValidationDomain(
            DateTime orderDate,
            decimal totalAmount,
            string status,
            int balance,
            int customerId
            )
        {
            //Validações das propriedades da entidade Order
            DomainExceptionValidation.When(totalAmount < 0,
                "Total amount cannot be negative");
            DomainExceptionValidation.When(string.IsNullOrEmpty(status),
                "Status is required");
            DomainExceptionValidation.When(balance < 0,
                "Balance cannot be negative");
            DomainExceptionValidation.When(customerId <= 0,
                "CustomerId must be greater than zero");

            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Status = status;
            Balance = balance;
            CustomerId = customerId;
        }
    }
}
