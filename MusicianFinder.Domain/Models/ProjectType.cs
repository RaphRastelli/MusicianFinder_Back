using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class ProjectType
    {
        public long ProjectTypeId { get; private set; }
        public string Type { get; private set; } = null!;

        // Ctor
        // Empty for EntityFramework
        private ProjectType() { }
    }
}
