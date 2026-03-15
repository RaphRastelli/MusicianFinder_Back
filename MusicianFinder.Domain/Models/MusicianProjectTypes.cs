using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianProjectTypes
    {
        public Musician? Musician { get; private set; }
        public IEnumerable<ProjectType>? ProjectTypeList { get; private set; }

    }
}
