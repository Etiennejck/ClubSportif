using ClubSportif.BLL.Interfaces;
using ClubSportif.DAL;
using ClubSportif.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly ClubSportifDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthService(ClubSportifDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            // Recherche de l'utilisateur par email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || !VerifyPassword(user, password))
            {
                throw new Exception("Identifiants invalides.");
            }

            // Génération du token JWT avec les claims nécessaires
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role) // Rôle : Joueur, Coach, Admin
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            // Vérification de l'unicité de l'email
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                throw new Exception("L'email est déjà utilisé.");
            }

            // Ici, vous devriez hacher le mot de passe avant de le stocker.
            user.MotDePasse = password; // Pour l'exemple, on stocke en clair (à ne pas faire en production)

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Méthode de vérification du mot de passe.
        /// Cette méthode doit être améliorée pour comparer un hash.
        /// </summary>
        private bool VerifyPassword(User user, string password)
        {
            // Pour l'exemple, nous comparons directement. En production, utilisez un algorithme de hachage.
            return user.MotDePasse == password;
        }
    }
}