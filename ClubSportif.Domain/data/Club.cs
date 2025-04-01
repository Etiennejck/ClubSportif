namespace ClubSportif.Domain.Entities
{
    public class Club
    {
        public int ClubID { get; set; }
        public required string Nom { get; set; }
        public required string Adresse { get; set; }
        public string? PhotoUrl { get; set; }
        public string? CouleurPrincipale { get; set; }
        public required string NumeroClub { get; set; }  // Doit être composé de 5 caractères

        // Navigation property
        public required ICollection<Section> Sections { get; set; }
    }
}