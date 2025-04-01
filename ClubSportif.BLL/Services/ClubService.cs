using ClubSportif.BLL.Interfaces;
using ClubSportif.DAL;
using ClubSportif.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubSportif.BLL.Services
{
    public class ClubService : IClubService
    {
       private readonly ClubSportifDbContext _context;
        public ClubService(ClubSportifDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Club>> GetAllClubsAsync()
        {
            return await _context.Clubs.ToListAsync();
        }
        public async Task<Club> GetClubByIdAsync(int id)
        {
            return await _context.Clubs.FindAsync(id);
        }
        public async Task<Club> CreateClubAsync(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();
            return club;
        }
        public async Task UpdateClubAsync(Club club)
        {
            _context.Clubs.Update(club);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteClubAsync(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                await _context.SaveChangesAsync();
            }
        }
    }
}
