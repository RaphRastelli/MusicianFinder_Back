using System.ComponentModel.DataAnnotations;

namespace MusicianFinder_Back.WebAPI.Dto.Request
{
    public class SearchRequestDto
    {
        [Required]
        public int InstrumentId { get; set; }

        [Required]
        public int LocationId { get; set; }

        // Liste car "Sans importance" envoie [1,2,3,4]
        [Required]
        [MinLength(1)]
        public List<int> AbilityIds { get; set; } = new();

        [Required]
        public int ProjectTypeId { get; set; }

        [Required]
        public int AvailabilityId { get; set; }

        [Required]
        public int MusicStyleId { get; set; }
    }
}
