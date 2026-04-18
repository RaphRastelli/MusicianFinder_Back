using MusicianFinder.Domain.Enums;
using MusicianFinder.Domain.Models;
using Musicianfinder_Back.ApplicationCore.DTOs;

namespace Musicianfinder_Back.ApplicationCore.Interfaces.Services
{
    public interface IMusicianService
    {
        Task<Musician> Login(string email, string password);
        Task<Musician> Register(string username, string email, string password);

        Task SaveInstrumentPrincipal(long musicianId, int instrumentId);
        Task SaveInstrumentsSecondaires(long musicianId, List<int> instrumentIds);
        Task SaveNiveau(long musicianId, AbilityLevelEnum ability);
        Task SaveProjectTypes(long musicianId, List<int> projectTypeIds);
        Task SaveDisponibilite(long musicianId, AvailabilityLevelEnum availability);
        Task SaveLocations(long musicianId, List<int> locationIds);
        Task SaveStylePrincipal(long musicianId, int styleId);
        Task SaveStylesSecondaires(long musicianId, List<int> styleIds);
        Task SaveDescription(long musicianId, string? description);
        Task<MusicianProfileAppDto?> GetProfileByIdAsync(long id);
        Task<MusicianProfileAppDto?> GetMyProfileAsync(long musicianId);
    }
}
