using ClubSportif.Domain.Entities;

namespace ClubSportif.BLL.Interfaces
{
    public interface IClubService
    {
        Task<IEnumerable<Club>> GetAllClubsAsync();
        Task<Club> GetClubByIdAsync(int id);
        Task<Club> CreateClubAsync(Club club);
        Task UpdateClubAsync(Club club);
        Task DeleteClubAsync(int id);
    }
}
