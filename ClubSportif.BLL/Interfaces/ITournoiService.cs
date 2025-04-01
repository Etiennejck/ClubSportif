using ClubSportif.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Interfaces
{
    public interface ITournoiService
    {
        Task<IEnumerable<Tournoi>> GetAllTournoisAsync();
        Task<Tournoi> GetTournoiByIdAsync(int id);
        Task<Tournoi> CreateTournoiAsync(Tournoi tournoi);
        Task UpdateTournoiAsync(Tournoi tournoi);
        Task DeleteTournoiAsync(int id);
    }
}
