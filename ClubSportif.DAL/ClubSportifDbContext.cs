using ClubSportif.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubSportif.DAL
{
    public class ClubSportifDbContext : DbContext
    {
        public ClubSportifDbContext(DbContextOptions<ClubSportifDbContext> options) : base(options)
        {
        }

        public DbSet<AbsenceStatus> AbsenceStatus { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ConvocationMatch> ConvocationsMatchs { get; set; }
        public DbSet<ConvocationTournoi> ConvocationsTournois { get; set; }
        public DbSet<Disponibilite> Disponibilites { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Tournoi> Tournois { get; set; }
        public DbSet<UserCategorie> UserCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Exemple de configuration avec Fluent API :
            // Contrainte sur le numéro du club (5 caractères maximum)
            modelBuilder.Entity<Club>()
                .Property(c => c.NumeroClub)
                .HasMaxLength(5);

            // Configuration de la relation entre User et Section
            modelBuilder.Entity<User>()
                .HasOne(u => u.Section)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SectionID);

            // Configuration de la relation entre Section et Club
            modelBuilder.Entity<Section>()
                .HasOne(s => s.Club)
                .WithMany(c => c.Sections)
                .HasForeignKey(s => s.ClubID);

            // Configuration de la relation entre User et sa catégorie de base
            modelBuilder.Entity<User>()
                .HasOne(u => u.BaseCategory)
                .WithMany()
                .HasForeignKey(u => u.BaseCategoryID);

            // Configuration de la relation entre User et UserCategories (Many-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserCategories)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.UserID);

            modelBuilder.Entity<UserCategorie>()
                .HasKey(uc => new { uc.UserID, uc.CategoryID });

            // Configuration de la relation entre User et Disponibilites
            modelBuilder.Entity<User>()
                .HasMany(u => u.Disponibilites)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserID);

            modelBuilder.Entity<Disponibilite>()
                .HasOne(d => d.User)
                .WithMany(u => u.Disponibilites)
                .HasForeignKey(d => d.UserID);

            // Configuration de la relation entre Match et Section
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Section)
                .WithMany() // Vous pouvez remplacer par .WithMany(s => s.Matchs) si la collection est définie dans Section
                .HasForeignKey(m => m.SectionID);

            // Configuration de la relation entre Categorie et UserCategories
            modelBuilder.Entity<Categorie>()
                .HasMany(c => c.UserCategories)
                .WithOne(uc => uc.Category)
                .HasForeignKey(uc => uc.CategoryID)
                .OnDelete(DeleteBehavior.Cascade); // Suppression en cascade

            // Définir explicitement la clé primaire pour l'entité Categorie
            modelBuilder.Entity<Categorie>().HasKey(c => c.CategoryID);

            modelBuilder.Entity<Categorie>()
                .Property(c => c.Nom)
                .HasMaxLength(10);

            // Définir explicitement la clé primaire pour AbsenceStatus
            modelBuilder.Entity<AbsenceStatus>().HasKey(a => a.StatusID);

            // Configuration pour ConvocationMatch (relation avec Match et User)
            modelBuilder.Entity<ConvocationMatch>()
                .HasOne(cm => cm.Match)
                .WithMany(m => m.ConvocationsMatchs) // Assurez-vous d'avoir cette propriété dans Match
                .HasForeignKey(cm => cm.MatchID);

            modelBuilder.Entity<ConvocationMatch>()
                .HasOne(cm => cm.User)
                .WithMany(u => u.ConvocationsMatchs) // Assurez-vous d'avoir cette propriété dans User
                .HasForeignKey(cm => cm.UserID);

            // Configuration pour ConvocationTournoi (relation avec Tournoi et User)
            modelBuilder.Entity<ConvocationTournoi>()
                .HasOne(ct => ct.Tournoi)
                .WithMany(t => t.ConvocationsTournois) // Assurez-vous d'avoir cette propriété dans Tournoi
                .HasForeignKey(ct => ct.TournoiID);

            modelBuilder.Entity<ConvocationTournoi>()
                .HasOne(ct => ct.User)
                .WithMany(u => u.ConvocationsTournois) // Assurez-vous d'avoir cette propriété dans User
                .HasForeignKey(ct => ct.UserID);

            // Autres configurations spécifiques selon vos besoins...
        }
    }
}