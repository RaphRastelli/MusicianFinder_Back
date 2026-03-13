using MusicianFinder.Domain.Enums;

namespace MusicianFinder.Domain.Models
{
    public class Musician
    {
        public long Id { get; private set; }
        public string? Username { get; private set; }
        public string? PasswordHash { get; private set; }
        public string Email { get; private set; } = default!;
        public string? Description { get; private set; }
        public MusicianRoleEnum Role { get; private set; }
        public AbilityLevelEnum Ability {  get; private set; }
        public AvailabilityLevelEnum Availability {  get; private set; }
        public string BgColor { get; private set; } = "#FFFFFF";
        public string FontFamily { get; private set; } = "Arial";
        public string TextColor { get; private set; } = "#000000";
        public DateTime CreatedAt { get; private set; } = DateTime.Now;


    }
}
