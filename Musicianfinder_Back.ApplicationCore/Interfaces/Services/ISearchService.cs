using Musicianfinder_Back.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musicianfinder_Back.ApplicationCore.Interfaces.Services
{
    public interface ISearchService
    {
        Task<SearchResultAppDto> SearchAsync(SearchRequestAppDto dto);
    }
}
