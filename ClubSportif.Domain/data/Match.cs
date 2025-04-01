namespace ClubSportif.Domain.Entities
{
    public class Match
    {
        public int MatchID { get; set; }
        public DateTime DateMatch { get; set; }
        public string Lieu { get; set; }
        public string? Description { get; set; }
        public int SectionID { get; set; }
        public Section Section { get; set; }
        public string Statut { get; set; }   // Ex. 'Match du jour', 'Saison'
        public string? Resultat { get; set; } // Résultat du match
        public ICollection<ConvocationMatch> ConvocationsMatchs { get; set; }
    }
}