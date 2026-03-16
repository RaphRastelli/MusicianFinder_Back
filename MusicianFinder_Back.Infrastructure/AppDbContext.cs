using Microsoft.EntityFrameworkCore;
using MusicianFinder.Domain.Models;
using System.Reflection;

namespace MusicianFinder_Back.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<MusicStyle> MusicStyles { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<MusicianPlaysInstrument> MusicianPlaysInstruments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MusicianLocation> MusicianLocations { get; set; }
        public DbSet<MusicianProjectType> MusicianProjectTypes { get; set; }
        public DbSet<MusicianLikesStyle> MusicianLikesStyles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationParticipant> ConversationParticipants { get; set; }


        // Définition du constructeur utilisé par l'injection de dépendance
        public AppDbContext(DbContextOptions options) : base(options) { }

        // Appliquer de la configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ajout automatique de l'assemby
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
