using ClubSportif.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Interfaces
{
    public interface IConvocationTournoiService
    {
        Task<IEnumerable<ConvocationTournoi>> GetAllConvocationTournoisAsync();
        Task<ConvocationTournoi> GetConvocationTournoiByIdAsync(int id);
        Task<ConvocationTournoi> CreateConvocationTournoiAsync(ConvocationTournoi convocationTournoi);
        Task UpdateConvocationTournoiAsync(ConvocationTournoi convocationTournoi);
        Task DeleteConvocationTournoiAsync(int id);
    }
}
