using ClubSportif.BLL.Interfaces;
using ClubSportif.DAL;
using ClubSportif.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Services
{
    public class ConvocationTournoiService :IConvocationTournoiService
    {
        private readonly ClubSportifDbContext _dbContext;

        public ConvocationTournoiService(ClubSportifDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ConvocationTournoi>> GetAllConvocationTournoisAsync()
        {
            return await _dbContext.ConvocationsTournois.ToListAsync();
        }

        public async Task<ConvocationTournoi> GetConvocationTournoiByIdAsync(int id)
        {
            return await _dbContext.ConvocationsTournois.FindAsync(id);
        }

        public async Task<ConvocationTournoi> CreateConvocationTournoiAsync(ConvocationTournoi convocationTournoi)
        {
            _dbContext.ConvocationsTournois.Add(convocationTournoi);
            await _dbContext.SaveChangesAsync();
            return convocationTournoi;
        }

        public async Task UpdateConvocationTournoiAsync(ConvocationTournoi convocationTournoi)
        {
            _dbContext.Entry(convocationTournoi).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteConvocationTournoiAsync(int id)
        {
            var convocationTournoi = await _dbContext.ConvocationsTournois.FindAsync(id);
            _dbContext.ConvocationsTournois.Remove(convocationTournoi);
            await _dbContext.SaveChangesAsync();
        }
    }
}
