using ClubSportif.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<Match>> GetAllMatchesAsync();
        Task<Match> GetMatchByIdAsync(int id);
        Task<Match> CreateMatchAsync(Match match);
        Task UpdateMatchAsync(Match match);
        Task DeleteMatchAsync(int id);
    }
}
