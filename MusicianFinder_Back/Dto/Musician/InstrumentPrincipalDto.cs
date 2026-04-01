using MusicianFinder.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicianFinder_Back.WebAPI.Dto.Musician
{
    // InstrumentPrincipalDto.cs
    public class InstrumentPrincipalDto
    {
        [Required]
        public int InstrumentId { get; set; }
    }

    // InstrumentsSecondairesDto.cs
    public class InstrumentsSecondairesDto
    {
        [Required]
        public List<int> InstrumentIds { get; set; } = new();
    }

    // NiveauDto.cs
    public class NiveauDto
    {
        [Required]
        public AbilityLevelEnum Ability { get; set; }
    }

    // DisponibiliteDto.cs
    public class DisponibiliteDto
    {
        [Required]
        public AvailabilityLevelEnum Availability { get; set; }
    }

    // LocationsDto.cs
    public class LocationsDto
    {
        [Required]
        public List<int> LocationIds { get; set; } = new();
    }

    // StylePrincipalDto.cs
    public class StylePrincipalDto
    {
        [Required]
        public int StyleId { get; set; }
    }

    // StylesSecondairesDto.cs
    public class StylesSecondairesDto
    {
        [Required]
        public List<int> StyleIds { get; set; } = new();
    }
}
