using ClubSportif.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categorie>> GetAllCategoriesAsync();
        Task<Categorie> GetCategoryByIdAsync(int id);
        Task<Categorie> CreateCategoryAsync(Categorie category);
        Task UpdateCategoryAsync(Categorie category);
        Task DeleteCategoryAsync(int id);
    }
}
