using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class Location
    {
        public int LocationId { get; private set; }
        public string LocationName { get; private set; } = null!;

        // Properties from other models
        public ICollection<MusicianLocation> Musicians { get; set; } = [];

        // Ctor
        // Vide pour EntityFramework
        private Location() { }

        // Ctor pour créer une localisation
        public Location(
           string locationName)
        {
            LocationName = locationName;
        }

        // Ctor pour récupérer une localisation
        public Location(int locationId, string locationName)
        {
            LocationId = locationId;
            LocationName = locationName;
        }
    }
}
