using GoldSystemSolutions.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{

    //Entidade de nota fiscal, onde serão armazenadas as informações das notas fiscais.
    public sealed class Invoce
    {
        public int Id { get; private set; }
        public string InvoceNumber { get; private set; }
        public DateTime IssueDate { get; private set; } //DATA DE EMISSÃO DA NF
        public DateTime? ShipmentDate { get; private set; } //DATA DE EMBARQUE DA NF
        public DateTime? DeliveryDate { get; private set; } //DATA DE ENTREGA DA NF
        public decimal TotalAmount { get; private set; } //TOTAL DO VALOR DA NF
        public int OrderId { get; private set; } //FOREIGN KEY
        public Order Order { get; private set; } //PROPERTY NAVIGATION
        public int CustomerId { get; private set; } //FOREIGN KEY
        public Customer Customer { get; private set; } //PROPERTY NAVIGATION
        public int CarrierId { get; private set; } //FOREIGN KEY
        public Carrier Carrier { get; private set; } //PROPERTY NAVIGATION
        public int WarehouseId { get; private set; } //FOREIGN KEY
        public Warehouse Warehouse { get; private set; } //PROPERTY NAVIGATION
        public int AddressId { get; private set; } //FOREIGN KEY
        public Address Address { get; private set; } //PROPERTY NAVIGATION
        public int InvoceStatus { get; private set; } //STATUS DA NF (0 = Pendente, 1 = Em rota de entrega, 2 = Entregue, 3 = Em devolução, 4 = Cancelado)
        public int InvoceItemsCount { get; private set; } //QUANTIDADE DE ITENS NA NF
        public required ICollection<InvoceItem> InvoceItems { get; set; } //PROPERTY NAVIGATION
        public decimal FreightCost { get; private set; } //CUSTO DO FRETE
        public decimal Weight { get; private set; } //PESO TOTAL DA NF

        public Invoce(
            string invoceNumber,
            DateTime issueDate,
            DateTime? shipmentDate,
            DateTime? deliveryDate,
            decimal totalAmount,
            int orderId,
            int customerId,
            int carrierId,
            int warehouseId,
            int addressId,
            int invoceStatus,
            int invoceItemsCount,
            decimal freightCost,
            decimal weight
            )
        {
            ValidationDomain(
                invoceNumber,
                issueDate,
                shipmentDate,
                deliveryDate,
                totalAmount,
                orderId,
                customerId,
                carrierId,
                warehouseId,
                addressId,
                invoceStatus,
                invoceItemsCount,
                freightCost,
                weight
                );
        }

        public Invoce(
            int Id,
            string invoceNumber,
            DateTime issueDate,
            DateTime? shipmentDate,
            DateTime? deliveryDate,
            decimal totalAmount,
            int orderId,
            int customerId,
            int carrierId,
            int warehouseId,
            int addressId,
            int invoceStatus,
            int invoceItemsCount,
            decimal freightCost,
            decimal weight
            )
        { 
        
            DomainExceptionValidation.When(Id < 0,
                "Invalid Id. Id must be greater than zero");
            Id = Id;
            ValidationDomain(
                invoceNumber,
                issueDate,
                shipmentDate,
                deliveryDate,
                totalAmount,
                orderId,
                customerId,
                carrierId,
                warehouseId,
                addressId,
                invoceStatus,
                invoceItemsCount,
                freightCost,
                weight
                );
        }

        public void UpdateInvoceStatus(int invoceStatus)
        {
            DomainExceptionValidation.When(invoceStatus < 0 || invoceStatus > 4,
                "Invalid Invoce Status. Invoce Status must be between 0 and 4");
            InvoceStatus = invoceStatus;
        }

        public void UpdateTotalAmount(decimal totalAmount)
        {
            DomainExceptionValidation.When(totalAmount < 0,
                "Invalid Total Amount. Total Amount must be greater than zero");
            TotalAmount = totalAmount;
        }

        public void UpdateFreightCost(decimal freightCost)
        {
            DomainExceptionValidation.When(freightCost < 0,
                "Invalid Freight Cost. Freight Cost must be greater than zero");
            FreightCost = freightCost;
        }

        public void UpdateWeight(decimal weight)
        {
            DomainExceptionValidation.When(weight < 0,
                "Invalid Weight. Weight must be greater than zero");
            Weight = weight;
        }

        public void UpdateInvoceItemsCount(int invoceItemsCount)
        {
            DomainExceptionValidation.When(invoceItemsCount < 0,
                "Invalid Invoce Items Count. Invoce Items Count must be greater than zero");
            InvoceItemsCount = invoceItemsCount;
        }

        public void UpdateAddressId(int addressId)
        {
            DomainExceptionValidation.When(addressId <= 0,
                "Invalid Address Id. Address Id must be greater than zero");
            AddressId = addressId;
        }

        public void UpdateWarehouseId(int warehouseId)
        {
            DomainExceptionValidation.When(warehouseId <= 0,
                "Invalid Warehouse Id. Warehouse Id must be greater than zero");
            WarehouseId = warehouseId;
        }

        public void UpdateCarrierId(int carrierId)
        {
            DomainExceptionValidation.When(carrierId <= 0,
                "Invalid Carrier Id. Carrier Id must be greater than zero");
            CarrierId = carrierId;
        }

        public void UpdateCustomerId(int customerId)
        {
            DomainExceptionValidation.When(customerId <= 0,
                "Invalid Customer Id. Customer Id must be greater than zero");
            CustomerId = customerId;
        }

        public void UpdateOrderId(int orderId)
        {
            DomainExceptionValidation.When(orderId <= 0,
                "Invalid Order Id. Order Id must be greater than zero");
            OrderId = orderId;
        }

        public void UpdateInvoceNumber(string invoceNumber)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(invoceNumber),
                "Invalid Invoce Number. Invoce Number is required");
            InvoceNumber = invoceNumber;
        }

        public void UpdateIssueDate(DateTime issueDate)
        {
            DomainExceptionValidation.When(ShipmentDate.HasValue && ShipmentDate < issueDate,
                "Invalid Issue Date. Issue Date must be less than Shipment Date");
            DomainExceptionValidation.When(DeliveryDate.HasValue && DeliveryDate < issueDate,
                "Invalid Issue Date. Issue Date must be less than Delivery Date");
            IssueDate = issueDate;
        }

        public void UpdateShipmentDateNullable(DateTime? shipmentDate)
        {
            if (shipmentDate.HasValue)
            {
                DomainExceptionValidation.When(shipmentDate < IssueDate,
                    "Invalid Shipment Date. Shipment Date must be greater than Issue Date");
            }
            ShipmentDate = shipmentDate;
        }

        public void UpdateDeliveryDateNullable(DateTime? deliveryDate)
        {
            if (deliveryDate.HasValue)
            {
                DomainExceptionValidation.When(deliveryDate < IssueDate,
                    "Invalid Delivery Date. Delivery Date must be greater than Issue Date");
                DomainExceptionValidation.When(ShipmentDate.HasValue && deliveryDate < ShipmentDate,
                    "Invalid Delivery Date. Delivery Date must be greater than Shipment Date");
            }
            DeliveryDate = deliveryDate;
        }

        public void ValidationDomain(
            string invoceNumber,
            DateTime issueDate,
            DateTime? shipmentDate,
            DateTime? deliveryDate,
            decimal totalAmount,
            int orderId,
            int customerId,
            int carrierId,
            int warehouseId,
            int addressId,
            int invoceStatus,
            int invoceItemsCount,
            decimal freightCost,
            decimal weight
            )
        {

            //Validações das propriedades da entidade Invoce
            DomainExceptionValidation.When(string.IsNullOrEmpty(invoceNumber),
                "Invalid Invoce Number. Invoce Number is required");
            DomainExceptionValidation.When(totalAmount < 0,
                "Invalid Total Amount. Total Amount must be greater than zero");
            DomainExceptionValidation.When(orderId <= 0,
                "Invalid Order Id. Order Id must be greater than zero");
            DomainExceptionValidation.When(customerId <= 0,
                "Invalid Customer Id. Customer Id must be greater than zero");
            DomainExceptionValidation.When(carrierId <= 0,
                "Invalid Carrier Id. Carrier Id must be greater than zero");
            DomainExceptionValidation.When(warehouseId <= 0,
                "Invalid Warehouse Id. Warehouse Id must be greater than zero");
            DomainExceptionValidation.When(addressId <= 0,
                "Invalid Address Id. Address Id must be greater than zero");
            DomainExceptionValidation.When(invoceStatus < 0 || invoceStatus > 4,
                "Invalid Invoce Status. Invoce Status must be between 0 and 4");
            DomainExceptionValidation.When(invoceItemsCount < 0,
                "Invalid Invoce Items Count. Invoce Items Count must be greater than zero");
            DomainExceptionValidation.When(freightCost < 0,
                "Invalid Freight Cost. Freight Cost must be greater than zero");
            DomainExceptionValidation.When(weight < 0,
                "Invalid Weight. Weight must be greater than zero");
            DomainExceptionValidation.When(shipmentDate.HasValue && shipmentDate < issueDate,
                "Invalid Shipment Date. Shipment Date must be greater than Issue Date");
            DomainExceptionValidation.When(deliveryDate.HasValue && deliveryDate < issueDate,
                "Invalid Delivery Date. Delivery Date must be greater than Issue Date");
            DomainExceptionValidation.When(deliveryDate.HasValue && shipmentDate.HasValue && deliveryDate < shipmentDate,
                "Invalid Delivery Date. Delivery Date must be greater than Shipment Date");
            DomainExceptionValidation.When(deliveryDate.HasValue && !shipmentDate.HasValue,
                "Invalid Delivery Date. Shipment Date is required when Delivery Date is provided");
           
            InvoceNumber = invoceNumber;
            IssueDate = issueDate;
            ShipmentDate = shipmentDate;
            DeliveryDate = deliveryDate;
            TotalAmount = totalAmount;
            OrderId = orderId;
            CustomerId = customerId;
            CarrierId = carrierId;
            WarehouseId = warehouseId;
            AddressId = addressId;
            InvoceStatus = invoceStatus;
            InvoceItemsCount = invoceItemsCount;
            FreightCost = freightCost;
            Weight = weight;
        }
    }
}
