using System;
using System.Collections.Generic;
using System.Text;

namespace Musicianfinder_Back.ApplicationCore.DTOs
{
    public class SearchRequestAppDto
    {
        public int InstrumentId { get; set; }
        public int LocationId { get; set; }
        public List<int> AbilityIds { get; set; } = new();
        public int ProjectTypeId { get; set; }
        public int AvailabilityId { get; set; }
        public int MusicStyleId { get; set; }
    }
}
