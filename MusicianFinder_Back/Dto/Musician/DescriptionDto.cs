using System.ComponentModel.DataAnnotations;

namespace MusicianFinder_Back.WebAPI.Dto.Musician
{
    public class DescriptionDto
    {
        [MaxLength(5000)]
        public string? Description { get; set; }
    }
}
