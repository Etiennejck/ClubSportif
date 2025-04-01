using ClubSportif.BLL.Interfaces;
using ClubSportif.DAL;
using ClubSportif.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Services
{
    public class ConvocationMatchService : IConvocationMatchService
    {

        private readonly ClubSportifDbContext _context;

        public ConvocationMatchService(ClubSportifDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConvocationMatch>> GetAllConvocationMatchesAsync()
        {
            return await _context.ConvocationsMatchs.ToListAsync();
        }

        public async Task<ConvocationMatch> GetConvocationMatchByIdAsync(int id)
        {
            return await _context.ConvocationsMatchs.FindAsync(id);
        }

        public async Task<ConvocationMatch> CreateConvocationMatchAsync(ConvocationMatch convocationMatch)
        {
            _context.ConvocationsMatchs.Add(convocationMatch);
            await _context.SaveChangesAsync();
            return convocationMatch;
        }

        public async Task UpdateConvocationMatchAsync(ConvocationMatch convocationMatch)
        {
            _context.Entry(convocationMatch).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConvocationMatchAsync(int id)
        {
            var convocationMatch = await _context.ConvocationsMatchs.FindAsync(id);
            _context.ConvocationsMatchs.Remove(convocationMatch);
            await _context.SaveChangesAsync();
        }
    }
}
