namespace ClubSportif.Domain.Entities
{
    public class ConvocationMatch
    {
        public int ConvocationMatchID { get; set; }
        public int MatchID { get; set; }
        public Match Match { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime DateConvocation { get; set; }
    }
}