using Musicianfinder_Back.ApplicationCore.DTOs;
using Musicianfinder_Back.ApplicationCore.Interfaces.Repositories;
using Musicianfinder_Back.ApplicationCore.Interfaces.Services;

namespace Musicianfinder_Back.ApplicationCore.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public async Task<SearchResultAppDto> SearchAsync(SearchRequestAppDto dto)
        {
            // Étape 1 — filtrage strict via le repository
            var musicians = await _searchRepository
                .GetMusiciansByInstrumentAsync(dto.InstrumentId);

            if (musicians.Count == 0)
            {
                return new SearchResultAppDto
                {
                    Musicians = new List<MusicianResultAppDto>(),
                    TotalCount = 0,
                    NoInstrumentMatch = true
                };
            }

            // Étape 2 — calcul du score et tri
            var scored = musicians
                .Select(m => new MusicianResultAppDto
                {
                    Id = m.Id,
                    Username = m.Username,
                    Score = CalculateScore(m, dto)
                })
                .OrderByDescending(x => x.Score)
                .ToList();

            return new SearchResultAppDto
            {
                Musicians = scored,
                TotalCount = scored.Count,
                NoInstrumentMatch = false
            };
        }

        private int CalculateScore(MusicianSearchAppDto m, SearchRequestAppDto dto)
        {
            int score = 0;

            // Priorité 1 — Instrument principal (1000)
            // Priorité 2 — Instrument secondaire (600)
            var instrumentMatch = m.Instruments
                .FirstOrDefault(p => p.InstrumentId == dto.InstrumentId);
            if (instrumentMatch != null)
                score += instrumentMatch.IsMainInstrument ? 1000 : 600;

            // Priorité 3 — Location (50)
            if (m.LocationIds.Contains(dto.LocationId))
                score += 50;

            // Priorité 4 — Ability (30)
            if (m.Ability.HasValue && dto.AbilityIds.Contains(m.Ability.Value))
                score += 30;

            // Priorité 5 — Availability (20)
            if (m.Availability.HasValue && m.Availability.Value == dto.AvailabilityId)
                score += 20;

            // Priorité 6 — ProjectType (15)
            if (m.ProjectTypeIds.Contains(dto.ProjectTypeId))
                score += 15;

            // Priorité 7 — Style principal (10)
            if (m.Styles.Any(s => s.StyleId == dto.MusicStyleId && s.IsMainStyle))
                score += 10;

            // Priorité 8 — Style secondaire (5)
            else if (m.Styles.Any(s => s.StyleId == dto.MusicStyleId && !s.IsMainStyle))
                score += 5;

            return score;
        }
    }
}