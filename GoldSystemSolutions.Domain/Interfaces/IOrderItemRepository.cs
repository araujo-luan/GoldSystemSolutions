using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync(); //Definição de contrato de forma async retornando uma lista de itens de pedido (OrderItem)
        Task<OrderItem> GetByIdAsync(int? id); //Busca um item de pedido pelo ID de forma async
        Task<OrderItem> GetOrderItemProductAsyc(int? id); //Busca o produto do item de pedido pelo ID de forma async 
        Task<OrderItem> GetOrderItemOrderAsync(int? id); //Busca o pedido do item de pedido pelo ID de forma async
        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem); //Cria um item de pedido de forma async
        Task<OrderItem> UpdateOrderItemAsync(OrderItem orderItem); //Atualiza um item de pedido de forma async
        Task<OrderItem> DeleteOrderItemAsync(int? id); //Deleta o item de pedido pelo ID

    }
}
