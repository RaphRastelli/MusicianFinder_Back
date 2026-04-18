using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musicianfinder_Back.ApplicationCore.DTOs;
using Musicianfinder_Back.ApplicationCore.Interfaces.Services;
using MusicianFinder_Back.WebAPI.Dto.Request;
using MusicianFinder_Back.WebAPI.Dto.Response;

namespace MusicianFinder_Back.WebAPI.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchRequestDto dto)
        {
            // Conversion DTO Presentation → DTO Application
            var appDto = new SearchRequestAppDto
            {
                InstrumentId = dto.InstrumentId,
                LocationId = dto.LocationId,
                AbilityIds = dto.AbilityIds,
                ProjectTypeId = dto.ProjectTypeId,
                AvailabilityId = dto.AvailabilityId,
                MusicStyleId = dto.MusicStyleId
            };

            var result = await _searchService.SearchAsync(appDto);

            // Conversion DTO Application → DTO Presentation
            return Ok(new SearchResultDto
            {
                Musicians = result.Musicians.Select(m => new MusicianResultDto
                {
                    Id = m.Id,
                    Username = m.Username,
                    Score = m.Score
                }).ToList(),
                TotalCount = result.TotalCount,
                NoInstrumentMatch = result.NoInstrumentMatch,
                NoMatch = result.NoMatch
            });
        }
    }
}