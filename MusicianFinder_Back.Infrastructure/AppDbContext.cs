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
            // Ajout automatique de l'assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        // Si je créais mes tables ici -> mais créées dans les Configs :
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                // Ajout automatique de l'assembly
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
            // clés composites, relations ...

            modelBuilder.Entity<Instrument>().HasData(
                new Instrument (1, "Chant masculin"),
                new Instrument (2, "Chant féminin"),
                new Instrument (3, "Guitare acoustique"),
                new Instrument (4, "Guitare électrique"),
                new Instrument (5, "Lap-Steel"),
                new Instrument (6, "Basse"),
                new Instrument (7, "Batterie"),
                new Instrument (8, "Percussions d’orchestre"),
                new Instrument (9, "Piano"),
                new Instrument (10, "Claviers/Synth"),
                new Instrument (11, "Clavecin"),
                new Instrument (12, "Orgue classique"),
                new Instrument (13, "Violon/Alto"),
                new Instrument (14, "Violoncelle"),
                new Instrument (15, "Contrebasse"),
                new Instrument (16, "Trompette"),
                new Instrument (17, "Trombone"),
                new Instrument (18, "Saxophone"),
                new Instrument (19, "Tuba"),
                new Instrument (20, "Clarinette"),
                new Instrument (21, "Flûte traversière"),
                new Instrument (22, "Hautbois/Basson"),
                new Instrument (23, "Cornemuse"),
                new Instrument (24, "Accordéon"),
                new Instrument (25, "Banjo"),
                new Instrument (26, "Luth"),
                new Instrument (27, "Turntable/DJ"),
                new Instrument (28, "Autre instrument acoustique"),
                new Instrument (29, "Autre instrument électrique"),
                new Instrument (30, "Autre instrument électronique")
            );

            modelBuilder.Entity<Location>().HasData(
                new Location (1, "Bruxelles"),
                new Location (2, "Brabant"),
                new Location (3, "Namur (ville)"),
                new Location (4, "Namur (province)"),
                new Location (5, "Liège (ville)"),
                new Location (6, "Liège (province)"),
                new Location (7, "Hainaut/Mons"),
                new Location (8, "Hainaut/Charleroi"),
                new Location (9, "Luxembourg"),
                new Location (10, "Anvers (ville)"),
                new Location (11, "Anvers (province)"),
                new Location (12, "Limbourg"),
                new Location (13, "Flandre Orientale"),
                new Location (14, "Flandre Occidentale")
            );

            modelBuilder.Entity<MusicStyle>().HasData(
                new MusicStyle (1, "Pop"),
                new MusicStyle (2, "Rock"),
                new MusicStyle (3, "Metal"),
                new MusicStyle (4, "Punk/Hardcore"),
                new MusicStyle (5, "Rock alternatif/post/indie"),
                new MusicStyle (6, "Folk"),
                new MusicStyle (7, "Chanson"),
                new MusicStyle (8, "Electro"),
                new MusicStyle (9, "Rap/Hip-Hop"),
                new MusicStyle (10, "Soul"),
                new MusicStyle (11, "Funk"),
                new MusicStyle (12, "Jeune Public"),
                new MusicStyle (13, "Jazz"),
                new MusicStyle (14, "Classique/Contemporain"),
                new MusicStyle (15, "Baroque/Ancien"),
                new MusicStyle (16, "Chorale"),
                new MusicStyle (17, "Reggae"),
                new MusicStyle (18, "Blues"),
                new MusicStyle (19, "Trad/World"),
                new MusicStyle (20, "Country"),
                new MusicStyle (21, "Fanfare"),
                new MusicStyle (22, "Cover")
            );
        }*/
    }
}
