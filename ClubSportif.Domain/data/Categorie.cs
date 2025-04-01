namespace ClubSportif.Domain.Entities
{
    public class Categorie
    {
        public int CategoryID { get; set; }
        public string Nom { get; set; }       // Ex. "U10", "U12", "U14"
        public int AgeValue { get; set; }       // Ex. 10, 12, 14
        public string Type { get; set; }        // Ex. "Provinciaux", "Régionaux", "Nationaux"

        // Navigation property
        public ICollection<UserCategorie> UserCategories { get; set; }
    }
}