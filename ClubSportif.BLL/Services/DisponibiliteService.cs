using ClubSportif.BLL.Interfaces;
using ClubSportif.DAL;
using ClubSportif.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Services
{
    internal class DisponibiliteService : IDisponibiliteService
    {
        private readonly ClubSportifDbContext _context;

        public DisponibiliteService(ClubSportifDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Disponibilite>> GetAllDisponibilitesAsync()
        {
            return await _context.Disponibilites.ToListAsync();
        }

        public async Task<Disponibilite> GetDisponibiliteByIdAsync(int id)
        {
            return await _context.Disponibilites.FindAsync(id);
        }

        public async Task<Disponibilite> CreateDisponibiliteAsync(Disponibilite disponibilite)
        {
            _context.Disponibilites.Add(disponibilite);
            await _context.SaveChangesAsync();
            return disponibilite;
        }

        public async Task UpdateDisponibiliteAsync(Disponibilite disponibilite)
        {
            _context.Entry(disponibilite).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDisponibiliteAsync(int id)
        {
            var disponibilite = await _context.Disponibilites.FindAsync(id);
            _context.Disponibilites.Remove(disponibilite);
            await _context.SaveChangesAsync();
        }
    }
}
