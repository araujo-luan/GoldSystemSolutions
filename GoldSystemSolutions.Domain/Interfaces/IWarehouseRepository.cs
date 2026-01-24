using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetWarehousesAsync(); //Definição de contrato de forma async retornando uma lista de armazéns (Warehouse)
        Task<Warehouse> GetByIdAsync(int? id); //Busca um armazém pelo ID de forma async
        Task<Warehouse> CreateWarehouseAsync(Warehouse warehouse); //Cria um armazém de forma async
        Task<Warehouse> UpdateWarehouseAsync(Warehouse warehouse); //Atualiza um armazém de forma async
        Task<Warehouse> DeleteWarehouseAsync(int? id); //Deleta o armazém pelo ID
    }
}
