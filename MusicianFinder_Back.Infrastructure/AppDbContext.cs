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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSeeding((context, _) =>
            {
                Instrument? instruChecker = context.Set<Instrument>().FirstOrDefault();
                if (instruChecker is null)
                {
                    context.Set<Instrument>().AddRange([
                        new Instrument("Chant masculin"),
                        new Instrument("Chant féminin"),
                        new Instrument("Guitare acoustique"),
                        new Instrument("Guitare électrique"),
                        new Instrument("Lap-Steel"),
                        new Instrument("Basse"),
                        new Instrument("Batterie"),
                        new Instrument("Percussions d’orchestre"),
                        new Instrument("Piano"),
                        new Instrument("Claviers/Synth"),
                        new Instrument("Clavecin"),
                        new Instrument("Orgue classique"),
                        new Instrument("Violon/Alto"),
                        new Instrument("Violoncelle"),
                        new Instrument("Contrebasse"),
                        new Instrument("Harpe"),
                        new Instrument("Trompette"),
                        new Instrument("Trombone"),
                        new Instrument("Cor"),
                        new Instrument("Tuba"),
                        new Instrument("Saxophone"),
                        new Instrument("Clarinette"),
                        new Instrument("Flûte traversière"),
                        new Instrument("Hautbois/Basson"),
                        new Instrument("Cornemuse"),
                        new Instrument("Accordéon"),
                        new Instrument("Banjo"),
                        new Instrument("Mandoline"),
                        new Instrument("Luth"),
                        new Instrument("Autre instrument acoustique"),
                        new Instrument("Autre instrument électrique"),
                        new Instrument("Autre instrument électronique")
                    ]);
                    context.SaveChanges();
                }

                Location? locationChecker = context.Set<Location>().FirstOrDefault();
                if (locationChecker is null)
                {
                    context.Set<Location>().AddRange([
                        new Location("Bruxelles"),
                        new Location("Brabant"),
                        new Location("Namur (ville)"),
                        new Location("Namur (province)"),
                        new Location("Liège (ville)"),
                        new Location("Liège (province)"),
                        new Location("Hainaut/Mons"),
                        new Location("Hainaut/Charleroi"),
                        new Location("Luxembourg"),
                        new Location("Anvers (ville)"),
                        new Location("Anvers (province)"),
                        new Location("Limbourg"),
                        new Location("Flandre Orientale"),
                        new Location("Flandre Occidentale")
                    ]);

                    context.SaveChanges();
                }

                MusicStyle? styleChecker = context.Set<MusicStyle>().FirstOrDefault();
                if (locationChecker is null)
                {
                    context.Set<MusicStyle>().AddRange([
                        new MusicStyle("Pop"),
                        new MusicStyle("Rock"),
                        new MusicStyle("Metal"),
                        new MusicStyle("Punk/Hardcore"),
                        new MusicStyle("Rock alternatif/post/indie"),
                        new MusicStyle("Folk"),
                        new MusicStyle("Chanson"),
                        new MusicStyle("Electro"),
                        new MusicStyle("Rap/Urban"),
                        new MusicStyle("Soul"),
                        new MusicStyle("Funk"),
                        new MusicStyle("Jeune Public"),
                        new MusicStyle("Jazz"),
                        new MusicStyle("Classique/Contemporain"),
                        new MusicStyle("Reggae"),
                        new MusicStyle("Blues"),
                        new MusicStyle("Trad/World"),
                        new MusicStyle("Fanfare"),
                        new MusicStyle("Cover"),
                    ]);

                    context.SaveChanges();
                }

            });
        }
    }
}
