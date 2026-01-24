using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync(); //Definição de contrato de forma async retornando uma lista de clientes (Customer)
        Task<Customer> GetByIdAsync(int? id); //Busca um cliente pelo ID de forma async
        Task<Customer> CreateCustomerAsync(Customer customer); //Cria um cliente de forma async
        Task<Customer> UpdateCustomerAsync(Customer customer); //Atualiza um cliente de forma async
        Task<Customer> DeleteCustomerAsync(int? id); //Deleta o cliente pelo ID
    }
}
