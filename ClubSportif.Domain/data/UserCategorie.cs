namespace ClubSportif.Domain.Entities
{
    public class UserCategorie
    {
        public int UserCategoryID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int CategoryID { get; set; }
        public Categorie Category { get; set; }
    }
}