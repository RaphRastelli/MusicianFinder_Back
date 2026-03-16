using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicStyle
    {
        public long StyleId { get; private set; }
        public string StyleName { get; private set; } = null!;

        // Ctor
        // Empty for EntityFramework
        private MusicStyle() { }
    }
}
