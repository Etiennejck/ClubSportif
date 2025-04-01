namespace ClubSportif.Domain.Entities
{
    public class Section
    {
        public int SectionID { get; set; }
        public string Nom { get; set; }
        public int ClubID { get; set; }
        public Club Club { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; }
    }
}