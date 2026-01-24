using GoldSystemSolutions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(); //Definição de contrato de forma async retornando uma lista de categorias (Category)
        Task<Category> GetByIdAsync(int? id); //Busca uma categoria pelo ID de forma async
        Task<Category> CreateCategoryAsync(Category category); //Cria uma categoria de forma async
        Task<Category> UpdateCategoryAsync(Category category); //Atualiza uma categoria de forma async
        Task<Category> DeleteCategoryAsync(int? id); //Deleta a categoria pelo ID

    }
}
