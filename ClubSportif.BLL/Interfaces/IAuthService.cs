using ClubSportif.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Valide les identifiants de l'utilisateur et retourne un token JWT si succès.
        /// </summary>
        /// <param name="email">L'email de l'utilisateur</param>
        /// <param name="password">Le mot de passe en clair</param>
        /// <returns>Le token JWT</returns>
        Task<string> LoginAsync(string email, string password);

        /// <summary>
        /// Enregistre un nouvel utilisateur dans le système.
        /// </summary>
        /// <param name="user">L'objet utilisateur</param>
        /// <param name="password">Le mot de passe en clair</param>
        /// <returns>L'utilisateur créé</returns>
        Task<User> RegisterAsync(User user, string password);
    }
}
