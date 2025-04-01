namespace ClubSportif.DTO.Auth
{
    public class RegisterRequest
    {
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }  // Par exemple "Joueur", "Coach", "Admin"
        // Ajoutez d'autres propriétés nécessaires à l'inscription
    }
}