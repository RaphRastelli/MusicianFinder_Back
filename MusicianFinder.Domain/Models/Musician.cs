using MusicianFinder.Domain.Enums;
using System.Net.Mail;
using System.Numerics;

namespace MusicianFinder.Domain.Models
{
    public class Musician
    {
        // Properties
        public long Id { get; private set; }
        public string Username { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public MusicianRoleEnum Role { get; private set; }
        public AbilityLevelEnum Ability { get; private set; }
        public AvailabilityLevelEnum Availability { get; private set; }
        public string BgColor { get; private set; } = "#FFFFFF";
        public string FontFamily { get; private set; } = "Arial";
        public string TextColor { get; private set; } = "#000000";
        public DateTime CreatedAt { get; private set; }

        // Properties from other models
        public ICollection<MusicianPlaysInstrument> MM_MusicianInstruments { get; set; } = [];
        public ICollection<Instrument> Instruments { get; set; } = [];
        public ICollection<MusicianLikesStyle> MM_MusicianMusicStyles { get; set; } = [];
        public ICollection<MusicStyle> MusicStyles { get; set; } = [];
        public ICollection<MusicianLocation> MM_MusicianLocations { get; set; } = [];
        public ICollection<Location> Locations { get; set; } = [];
        public ICollection<MusicianProjectType> MM_MusicianProjectTypes { get; set; } = [];
        public ICollection<ProjectType> ProjectTypes { get; set; } = [];

        // Ctor
        // Vide pour EntityFramework
        private Musician() { }

        // ctor pour base de la création d'un Musician (avec validation email et username entre 4 et 50 caractères)
        public Musician(string username, string email, string? passwordhash = null)
        {
            if (username is null || username.Trim().Length < 4 || username.Trim().Length > 50) 
                throw new ArgumentException("Le username doit contenir entre 4 et 50 caractères.", nameof(username));

            if (string.IsNullOrWhiteSpace(email) || !MailAddress.TryCreate(email, out _))
                throw new ArgumentException("E-mail invalide.", nameof(email));

            Username = username.Trim();
            Email = email.Trim().ToLower();
            CreatedAt = DateTime.Now;
        }

        // ctor avec id pour récup et insertion en db simple
        public Musician(long id, string username, string email, string? passwordhash = null)
            :this(username, email, passwordhash)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        // ctor avec id pour récup et insertion en db
        public Musician(long id, string username, string email, DateTime createdAt, string description, MusicianRoleEnum role, AbilityLevelEnum ability, AvailabilityLevelEnum availability, string bgColor, string fontFamily, string textColor, string? passwordhash = null)
            :this(username, email, passwordhash)
        { 
            Id = id;
            Email = email;
            Role = role;
        }

        // TODO ctor pour update



    }
}
