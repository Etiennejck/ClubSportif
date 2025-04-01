namespace ClubSportif.Domain.Entities
{
    public class AbsenceStatus
    {
        public int StatusID { get; set; }
        public string Libelle { get; set; } // Ex. "malade", "blessé", etc.
    }
}