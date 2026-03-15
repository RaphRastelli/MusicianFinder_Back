using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class Location
    {
        public long LocationId { get; private set; }
        public string? LocationName { get; private set; }
    }
}
