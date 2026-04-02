using MusicianFinder.Domain.Enums;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musicianfinder_Back.ApplicationCore.Interfaces.Repositories
{
    public interface IMusicianRepository
    {
        Musician? GetById(long id);
        Musician? GetByEmail(string email);
        string? GetHashPwd(string email);
        Musician Insert(Musician musician);

        // ── Instruments ───────────────────────────────────────────────────
        Task SaveInstrumentPrincipalAsync(long musicianId, int instrumentId);
        Task SaveInstrumentsSecondairesAsync(long musicianId, List<int> instrumentIds);

        // ── Profil ────────────────────────────────────────────────────────
        Task SaveNiveauAsync(long musicianId, AbilityLevelEnum ability);
        Task SaveDisponibiliteAsync(long musicianId, AvailabilityLevelEnum availability);

        // ── Locations ─────────────────────────────────────────────────────
        Task SaveLocationsAsync(long musicianId, List<int> locationIds);

        // ── ProjectType ───────────────────────────────────────────────────
        Task SaveProjectTypesAsync(long musicianId, List<int> projectTypeIds);

        // ── Styles ────────────────────────────────────────────────────────
        Task SaveStylePrincipalAsync(long musicianId, int styleId);
        Task SaveStylesSecondairesAsync(long musicianId, List<int> styleIds);

        // ── Description ───────────────────────────────────────────────────
        Task SaveDescriptionAsync(long musicianId, string? description);

    }
}
