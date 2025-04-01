namespace ClubSportif.Domain.Entities
{
    public class Disponibilite
    {
        public int DisponibiliteID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime DateDisponibilite { get; set; }
        public string Statut { get; set; }      // Ex. 'Disponible', 'Non Disponible'
        public bool Presence { get; set; }        // Indique si le joueur était présent
        public int? AbsenceStatusID { get; set; }
        public AbsenceStatus? AbsenceStatus { get; set; }
    }
}