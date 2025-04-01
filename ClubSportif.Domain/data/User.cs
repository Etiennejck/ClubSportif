namespace ClubSportif.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; set; } // 'Joueur', 'Coach', 'Admin'
        public int? SectionID { get; set; }
        public Section? Section { get; set; }
        public int? BaseCategoryID { get; set; }
        public Categorie? BaseCategory { get; set; }
        public string? CertificatUrl { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Adresse { get; set; }
        public int? NumeroMaillot { get; set; }  // Pour les joueurs
        public decimal? Taille { get; set; }      // En mètres
        public decimal? Poids { get; set; }       // En kg

        // Navigation properties
        public ICollection<UserCategorie> UserCategories { get; set; }
        public ICollection<Disponibilite> Disponibilites { get; set; }
        public ICollection<ConvocationMatch> ConvocationsMatchs { get; set; }
        public ICollection<ConvocationTournoi> ConvocationsTournois { get; set; }
    }
}