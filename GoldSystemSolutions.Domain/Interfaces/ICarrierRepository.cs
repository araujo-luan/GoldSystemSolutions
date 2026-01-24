using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface ICarrierRepository
    {
        Task<IEnumerable<Carrier>> GetCarriersAsync(); //Definição de contrato de forma async retornando uma lista de transportadoras (Carrier)
        Task<Carrier> GetByIdAsync(int? id); //Busca uma transportadora pelo ID de forma async
        Task<Carrier> CreateCarrierAsync(Carrier carrier); //Cria uma transportadora de forma async
        Task<Carrier> UpdateCarrierAsync(Carrier carrier); //Atualiza uma transportadora de forma async
        Task<Carrier> DeleteCarrierAsync(int? id); //Deleta a transportadora pelo ID
    }
}
