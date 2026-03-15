using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class ProjectType
    {
        public long TypeId { get; private set; }
        public string? Type { get; private set; }
    }
}
