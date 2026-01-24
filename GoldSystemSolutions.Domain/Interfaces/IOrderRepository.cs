using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync(); //Definição de contrato de forma async retornando uma lista de pedidos (Order)
        Task<Order> GetByIdAsync(int? id); //Busca um pedido pelo ID de forma async
        Task<Order> GetOrderByCustomerIdAsync(int? customerId); //Busca um pedido pelo ID do cliente de forma async
        Task<Order> CreateOrderAsync(Order order); //Cria um pedido de forma async
        Task<Order> UpdateOrderAsync(Order order); //Atualiza um pedido de forma async
        Task<Order> DeleteOrderAsync(int? id); //Deleta o pedido pelo ID

    }
}
