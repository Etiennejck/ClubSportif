using ClubSportif.BLL.Interfaces;
using ClubSportif.DAL;
using ClubSportif.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Services
{
    public class TournoiService : ITournoiService
    {
        private readonly ClubSportifDbContext _context;

        public TournoiService(ClubSportifDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tournoi>> GetAllTournoisAsync()
        {
            return await _context.Tournois.ToListAsync();
        }

        public async Task<Tournoi> GetTournoiByIdAsync(int id)
        {
            return await _context.Tournois.FindAsync(id);
        }

        public async Task<Tournoi> CreateTournoiAsync(Tournoi tournoi)
        {
            _context.Tournois.Add(tournoi);
            await _context.SaveChangesAsync();
            return tournoi;
        }

        public async Task UpdateTournoiAsync(Tournoi tournoi)
        {
            _context.Entry(tournoi).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTournoiAsync(int id)
        {
            var tournoi = await _context.Tournois.FindAsync(id);
            _context.Tournois.Remove(tournoi);
            await _context.SaveChangesAsync();
        }
    }

}
