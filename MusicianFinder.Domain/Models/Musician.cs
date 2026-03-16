using MusicianFinder.Domain.Enums;
using System.Numerics;

namespace MusicianFinder.Domain.Models
{
    public class Musician
    {
        // Properties
        public long Id { get; private set; }
        public string Username { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public string Email { get; private set; } = default!;
        public string Description { get; private set; } = null!;
        public MusicianRoleEnum Role { get; private set; }
        public AbilityLevelEnum Ability { get; private set; }
        public AvailabilityLevelEnum Availability { get; private set; }
        public string BgColor { get; private set; } = "#FFFFFF";
        public string FontFamily { get; private set; } = "Arial";
        public string TextColor { get; private set; } = "#000000";
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        // Properties from other models
        public ICollection<MusicianPlaysInstrument> Instruments { get; set; } = [];
        public ICollection<MusicianLikesStyle> MusicStyles { get; set; } = [];
        public ICollection<MusicianLocation> Locations { get; set; } = [];
        public ICollection<MusicianProjectType> ProjectTypes { get; set; } = [];

        // Ctor
        // Empty for EntityFramework
        private Musician() { }

    }
}
