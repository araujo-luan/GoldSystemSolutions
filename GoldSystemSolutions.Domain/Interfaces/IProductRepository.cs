using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(); //Definição de contrato de forma async retornando uma lista de produtos (Product)
        Task<Product> GetByIdAsync(int? id); //Busca um produto pelo ID de forma async
        Task<Product> GetProductCategoryAsync(int? id); //Busca a categoria do produto pelo ID de forma async) 
        Task<Product> CreateProductAsync(Product product); //Cria um produto de forma async
        Task<Product> UpdateProductAsync(Product product); //Atualiza um produto de forma async
        Task<Product> DeleteProductAsync(int? id); //Deleta o produto pelo ID

    }
}
