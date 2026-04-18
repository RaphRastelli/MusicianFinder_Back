using Microsoft.EntityFrameworkCore;
using Musicianfinder_Back.ApplicationCore.DTOs;
using Musicianfinder_Back.ApplicationCore.Interfaces.Repositories;

namespace MusicianFinder_Back.Infrastructure.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly AppDbContext _dbContext;

        public SearchRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MusicianSearchAppDto>> GetMusiciansByInstrumentAsync(
            int instrumentId, int locationId)
        {
            var musicians = await _dbContext.Musicians
                .Include(m => m.MM_MusicianInstruments)
                .Include(m => m.MM_MusicianLocations)
                .Include(m => m.MM_MusicianMusicStyles)
                .Include(m => m.MM_MusicianProjectTypes)
                // Filtrage strict : Instrument ET Location obligatoires
                .Where(m =>
                     m.MM_MusicianInstruments.Any(p => p.InstrumentIdFK == instrumentId) &&
                     m.MM_MusicianLocations.Any(l => l.LocationIdFK == locationId))
                .ToListAsync();

            // Conversion entités Domain → DTOs Application
            return musicians.Select(m => new MusicianSearchAppDto
            {
                Id = m.Id,
                Username = m.Username,
                Ability = m.Ability.HasValue ? (int?)m.Ability.Value : null,
                Availability = m.Availability.HasValue ? (int?)m.Availability.Value : null,
                Instruments = m.MM_MusicianInstruments.Select(i =>
                    new MusicianInstrumentAppDto
                    {
                        InstrumentId = i.InstrumentIdFK,
                        IsMainInstrument = i.IsMainInstrument
                    }).ToList(),
                LocationIds = m.MM_MusicianLocations.Select(l => l.LocationIdFK).ToList(),
                ProjectTypeIds = m.MM_MusicianProjectTypes.Select(pt => pt.ProjectTypeIdFK).ToList(),
                Styles = m.MM_MusicianMusicStyles.Select(s =>
                    new MusicianStyleAppDto
                    {
                        StyleId = s.StyleIdFK,
                        IsMainStyle = s.IsMainStyle
                    }).ToList(),
            }).ToList();
        }
    }
}