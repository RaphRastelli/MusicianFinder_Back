using System.ComponentModel.DataAnnotations;

namespace MusicianFinder_Back.WebAPI.Dto.Musician
{
    public class ProjectTypesDto
    {
        [Required]
        public List<int> ProjectTypeIds { get; set; } = new();
    }
}
