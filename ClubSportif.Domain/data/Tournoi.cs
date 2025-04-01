namespace ClubSportif.Domain.Entities
{
    public class Tournoi
    {
        public int TournoiID { get; set; }
        public string Nom { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int SectionID { get; set; }
        public Section Section { get; set; }
        public string? Resultat { get; set; } // Résultat du tournoi
        public ICollection<ConvocationTournoi> ConvocationsTournois { get; set; }
    }
}