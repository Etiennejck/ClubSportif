using ClubSportif.BLL.Interfaces;
using ClubSportif.DAL;
using ClubSportif.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Services
{
    public class MatchService :IMatchService
    {
        private readonly ClubSportifDbContext _context;

        public MatchService(ClubSportifDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetAllMatchesAsync()
        {
            return await _context.Matchs.ToListAsync();
        }

        public async Task<Match> GetMatchByIdAsync(int id)
        {
            return await _context.Matchs.FindAsync(id);
        }

        public async Task<Match> CreateMatchAsync(Match match)
        {
            _context.Matchs.Add(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task UpdateMatchAsync(Match match)
        {
            _context.Entry(match).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMatchAsync(int id)
        {
            var match = await _context.Matchs.FindAsync(id);
            _context.Matchs.Remove(match);
            await _context.SaveChangesAsync();
        }
    }
}
