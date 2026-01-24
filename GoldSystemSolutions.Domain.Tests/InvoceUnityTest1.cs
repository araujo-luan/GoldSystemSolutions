using FluentAssertions;
using GoldSystemSolutions.Domain.Entities;
using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Tests
{
    public class InvoceUnityTest1
    {

        [Fact(DisplayName = "Create Invoce With Valid Parameters")]
        public void CreateInvoce_WithValid_Parameters()
        {
            Action action = () => new Invoce(
                "12445879",
                DateTime.Now,
                new DateTime(2026, 1, 24, 21, 43, 0),
                new DateTime(2026, 1, 25, 10, 25, 20),
                new decimal(100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(10.00),
                new decimal(5.5)
            );

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Invoce With Invalid Number")]
        public void CreateInvoce_WithInvalidNumber_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Invoce(
                "",
                DateTime.Now,
                new DateTime(2026, 1, 24, 21, 43, 0),
                new DateTime(2026, 1, 25, 10, 25, 20),
                new decimal(100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(10.00),
                new decimal(5.5)
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Number. Number is required");
        }

        [Fact(DisplayName = "Create Invoce With Invalid Id")]
        public void CreateInvoce_WithInvalidId_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Invoce(
                -1,
                "12445879",
                DateTime.Now,
                new DateTime(2026, 1, 24, 21, 43, 0),
                new DateTime(2026, 1, 25, 10, 25, 20),
                new decimal(100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(10.00),
                new decimal(5.5)
                );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id must be greater than zero");
        }

        [Fact(DisplayName = "Create Invoce With Negative Total Amount")]
        public void CreateInvoce_WithNegativeTotalAmount_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Invoce(
                "12445879",
                DateTime.Now,
                new DateTime(2026, 1, 24, 21, 43, 0),
                new DateTime(2026, 1, 25, 10, 25, 20),
                new decimal(-100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(10.00),
                new decimal(5.5)
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Total Amount. Total Amount must be non-negative");
        }

        [Fact(DisplayName = "Create Invoce With Invalid Due Date")]
        public void CreateInvoce_WithInvalidDueDate_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Invoce(
                "12445879",
                DateTime.Now,
                new DateTime(2026, 1, 25, 10, 25, 20),
                new DateTime(2026, 1, 24, 21, 43, 0),
                new decimal(100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(10.00),
                new decimal(5.5)
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Due Date. Due Date must be after Issue Date");
        }

        [Fact(DisplayName = "Create Invoce With Negative Tax Amount")]
        public void CreateInvoce_WithNegativeTaxAmount_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Invoce(
                "12445879",
                DateTime.Now,
                new DateTime(2026, 1, 24, 21, 43, 0),
                new DateTime(2026, 1, 25, 10, 25, 20),
                new decimal(100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(-10.00),
                new decimal(5.5)
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Tax Amount. Tax Amount must be non-negative");
        }

        [Fact(DisplayName = "Create Invoce With Invalid Delivery date")]
        public void CreateInvoce_WithInvalidTaxRate_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Invoce(
                "12445879",
                DateTime.Now,
                new DateTime(2026, 1, 24, 21, 43, 0),
                new DateTime(2026, 1, 24, 10, 25, 20),
                new decimal(100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(10.00),
                new decimal(150.0)
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Delivery Date. Delivery Date must be greater than Shipment Date");
        }

        [Fact(DisplayName = "Create Invoce With Invalid Dalivery Date < IssueDate")]
        public void CreateInvoce_WithInvalidDeliveryDate_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Invoce(
                "12445879",
                DateTime.Now,
                new DateTime(2026, 1, 24, 21, 43, 0),
                new DateTime(2026, 1, 23, 10, 25, 20),
                new decimal(100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(10.00),
                new decimal(5.5)
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Delivery Date. Delivery Date must be after Shipment Date");
        }

        [Fact(DisplayName = "Create Invoce With Invalid Shipment Date < IssueDate")]
        public void CreateInvoce_WithInvalidShipmentDate_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Invoce(
                "12445879",
                DateTime.Now,
                new DateTime(2026, 1, 23, 21, 43, 0),
                new DateTime(2026, 1, 25, 10, 25, 20),
                new decimal(100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(10.00),
                new decimal(5.5)
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Shipment Date. Shipment Date must be after Issue Date");
        }

        [Fact(DisplayName = "Create Invoce With Negative Tax Rate")]
        public void CreateInvoce_WithNegativeTaxRate_ShouldThrowDomainExceptionValidation()
        {
            Action action = () => new Invoce(
                "12445879",
                DateTime.Now,
                new DateTime(2026, 1, 24, 21, 43, 0),
                new DateTime(2026, 1, 25, 10, 25, 20),
                new decimal(100.00),
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                new decimal(10.00),
                new decimal(-5.5)
            );
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Weight. Weight must be greater than zero");
        }

    }
}
