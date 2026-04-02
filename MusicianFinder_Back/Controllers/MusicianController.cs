using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicianFinder.Domain.Enums;
using Musicianfinder_Back.ApplicationCore.Interfaces.Services;
using MusicianFinder_Back.WebAPI.Dto.Musician;
using MusicianFinder_Back.WebAPI.Dto.Response;
using System.Security.Claims;

namespace MusicianFinder_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("api/musicians")]
    [Authorize]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianService _musicianService;

        public MusicianController(IMusicianService musicianService)
        {
            _musicianService = musicianService;
        }

        // Lit le MusicianId depuis le claim du JWT
        private long GetMusicianIdFromToken()
        {
            var claim = User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new UnauthorizedAccessException("Token invalide.");
            return long.Parse(claim);
        }

        [HttpPut("me/instrument-principal")]
        public async Task<IActionResult> SaveInstrumentPrincipal(
            [FromBody] InstrumentPrincipalDto dto)
        {
            var musicianId = GetMusicianIdFromToken();
            await _musicianService.SaveInstrumentPrincipal(musicianId, dto.InstrumentId);
            return Ok();
        }

        [HttpPut("me/instruments-secondaires")]
        public async Task<IActionResult> SaveInstrumentsSecondaires(
            [FromBody] InstrumentsSecondairesDto dto)
        {
            var musicianId = GetMusicianIdFromToken();
            await _musicianService.SaveInstrumentsSecondaires(musicianId, dto.InstrumentIds);
            return Ok();
        }

        [HttpPatch("me/niveau")]
        public async Task<IActionResult> SaveNiveau([FromBody] NiveauDto dto)
        {
            var musicianId = GetMusicianIdFromToken();
            await _musicianService.SaveNiveau(musicianId, dto.Ability);
            return Ok();
        }

        [HttpPut("me/project-types")]
        public async Task<IActionResult> SaveProjectTypes([FromBody] ProjectTypesDto dto)
        {
            var musicianId = GetMusicianIdFromToken();
            await _musicianService.SaveProjectTypes(musicianId, dto.ProjectTypeIds);
            return Ok();
        }

        [HttpPatch("me/disponibilite")]
        public async Task<IActionResult> SaveDisponibilite([FromBody] DisponibiliteDto dto)
        {
            var musicianId = GetMusicianIdFromToken();
            await _musicianService.SaveDisponibilite(musicianId, dto.Availability);
            return Ok();
        }

        [HttpPut("me/locations")]
        public async Task<IActionResult> SaveLocations([FromBody] LocationsDto dto)
        {
            var musicianId = GetMusicianIdFromToken();
            await _musicianService.SaveLocations(musicianId, dto.LocationIds);
            return Ok();
        }

        [HttpPut("me/style-principal")]
        public async Task<IActionResult> SaveStylePrincipal([FromBody] StylePrincipalDto dto)
        {
            var musicianId = GetMusicianIdFromToken();
            await _musicianService.SaveStylePrincipal(musicianId, dto.StyleId);
            return Ok();
        }

        [HttpPut("me/styles-secondaires")]
        public async Task<IActionResult> SaveStylesSecondaires(
            [FromBody] StylesSecondairesDto dto)
        {
            var musicianId = GetMusicianIdFromToken();
            await _musicianService.SaveStylesSecondaires(musicianId, dto.StyleIds);
            return Ok();
        }

        [HttpPatch("me/description")]
        public async Task<IActionResult> SaveDescription([FromBody] DescriptionDto dto)
        {
            var musicianId = GetMusicianIdFromToken();
            await _musicianService.SaveDescription(musicianId, dto.Description);
            return Ok();
        }

        // Accessible à tous — pas de [Authorize]
        // Un visiteur non connecté peut consulter un profil
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(long id)
        {
            var profile = await _musicianService.GetProfileByIdAsync(id);

            if (profile is null)
                return NotFound();

            // Conversion DTO Application → DTO Presentation
            return Ok(new MusicianProfileDto
            {
                Username = profile.Username,
                InstrumentPrincipal = profile.InstrumentPrincipal,
                Ability = profile.Ability,
                InstrumentsSecondaires = profile.InstrumentsSecondaires,
                StylePrincipal = profile.StylePrincipal,
                StylesSecondaires = profile.StylesSecondaires,
                Locations = profile.Locations,
                ProjectTypes = profile.ProjectTypes,
                Availability = profile.Availability,
                Description = profile.Description,
                Email = profile.Email
            });
        }
    }
}
