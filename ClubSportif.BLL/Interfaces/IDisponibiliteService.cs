using ClubSportif.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Interfaces
{
    internal interface IDisponibiliteService
    {
        Task<IEnumerable<Disponibilite>> GetAllDisponibilitesAsync();
        Task<Disponibilite> GetDisponibiliteByIdAsync(int id);
        Task<Disponibilite> CreateDisponibiliteAsync(Disponibilite disponibilite);
        Task UpdateDisponibiliteAsync(Disponibilite disponibilite);
        Task DeleteDisponibiliteAsync(int id);
    }
}
