using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianLocations
    {
        public Musician? Musician { get; private set; }
        public IEnumerable<Location>? LocationList { get; private set; }
    }
}
