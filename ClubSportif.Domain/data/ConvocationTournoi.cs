namespace ClubSportif.Domain.Entities
{
    public class ConvocationTournoi
    {
        public int ConvocationTournoiID { get; set; }
        public int TournoiID { get; set; }
        public Tournoi Tournoi { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime DateConvocation { get; set; }
    }
}