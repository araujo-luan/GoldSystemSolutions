using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Entities
{
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
    }
}
