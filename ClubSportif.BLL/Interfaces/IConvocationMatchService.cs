using ClubSportif.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Interfaces
{
    public interface IConvocationMatchService
    {
        Task<IEnumerable<ConvocationMatch>> GetAllConvocationMatchesAsync();
        Task<ConvocationMatch> GetConvocationMatchByIdAsync(int id);
        Task<ConvocationMatch> CreateConvocationMatchAsync(ConvocationMatch convocationMatch);
        Task UpdateConvocationMatchAsync(ConvocationMatch convocationMatch);
        Task DeleteConvocationMatchAsync(int id);
    }
}
