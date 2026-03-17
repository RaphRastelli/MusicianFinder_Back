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
        // Vide pour EntityFramework
        private MusicStyle() { }

        // Ctor pour créer un style
        public MusicStyle(
           string styleName)
        {
            StyleName = styleName;
        }

        // Ctor pour récupérer un style
        public MusicStyle(long styleId, string styleName)
        {
            StyleId = styleId;
            StyleName = styleName;
        }
    }
}
