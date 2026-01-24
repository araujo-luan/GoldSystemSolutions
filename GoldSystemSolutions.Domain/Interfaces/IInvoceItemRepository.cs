using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface IInvoceItemRepository
    {
        Task<IEnumerable<InvoceItem>> GetInvoceItemsAsync(); //Definição de contrato de forma async retornando uma lista de itens de fatura (InvoceItem)
        Task<InvoceItem> GetByIdAsync(int? id); //Busca um item de fatura pelo ID de forma async
        Task<InvoceItem> GetInvoceItemInvoceAsync(int? id); //Busca a fatura do item de fatura pelo ID de forma async
        Task<InvoceItem> GetInvoceItemProductAsync(int? id); //Busca o produto do item de fatura pelo ID de forma async
        Task<InvoceItem> GetInvoceItemOrderAsync(int? id); //Busca o pedido do item de fatura pelo ID de forma async
        Task<InvoceItem> CreateInvoceItemAsync(InvoceItem invoceItem); //Cria um item de fatura de forma async
        Task<InvoceItem> UpdateInvoceItemAsync(InvoceItem invoceItem); //Atualiza um item de fatura de forma async
        Task<InvoceItem> DeleteInvoceItemAsync(int? id); //Deleta o item de fatura pelo ID

    }
}
