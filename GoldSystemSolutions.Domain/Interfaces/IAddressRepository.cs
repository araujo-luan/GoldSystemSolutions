using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface IAddressRepository
    {

        Task<IEnumerable<Address>> GetAddressAsync(); //Definição de contrato de forma async retornando uma lista de endereços (Address)
        Task<Address> GetByIdAsync(int? id); //Busca um endereço pelo ID de forma async
        Task<Address> GetAddressCustomer(int? id); //Busca o cliente do endereço pelo ID de forma async
        Task<Address> GetAddressCarrier(int? id); //Busca a transportadora do endereço pelo ID de forma async
        Task<Address> GetAddressWarehouse(int? id); //Busca o depósito do endereço pelo ID de forma async
        Task<Address> CreateAddressAsync(Address address); //Cria um endereço de forma async
        Task<Address> UpdateAddressAsync(Address address); //Atualiza um endereço de forma async
        Task<Address> DeleteAddressAsync(int? id); //Deleta o endereço pelo ID

    }
}
