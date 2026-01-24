using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface IInvoceRepository
    {
        Task<IEnumerable<Invoce>> GetInvocesAsync(); //Definição de contrato de forma async retornando uma lista de faturas (Invoce)
        Task<Invoce> GetByIdAsync(int? id); //Busca uma fatura pelo ID de forma async
        Task<Invoce> GetInvoceCarrierAsyn(int? id); //Busca a transportadora da fatura pelo ID de forma async
        Task<Invoce> GetInvoceCustomerAsync(int? id); //Busca o cliente da fatura pelo ID de forma async
        Task<Invoce> GetInvoceOrderAsync(int? id); //Busca o pedido da fatura pelo ID de forma async
        Task<Invoce> GetInvoceWarehouseAsync(int? id); //Busca o armazém da fatura pelo ID de forma async
        Task<Invoce> GetInvoceAddressAsync(int? id); //Busca o endereço da fatura pelo ID de forma async
        Task<Invoce> CreateInvoceAsync(Invoce invoce); //Cria uma fatura de forma async
        Task<Invoce> UpdateInvoceAsync(Invoce invoce); //Atualiza uma fatura de forma async
        Task<Invoce> DeleteInvoceAsync(int? id); //Deleta a fatura pelo ID

    }
}
