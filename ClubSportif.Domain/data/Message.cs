namespace ClubSportif.Domain.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public int ExpediteurID { get; set; }
        public User Expediteur { get; set; }
        public int DestinataireID { get; set; }
        public User Destinataire { get; set; }
        public DateTime DateEnvoi { get; set; }
        public string Contenu { get; set; }
    }
}