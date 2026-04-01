using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianLikesStyle
    {
        public int MusicianStyleId { get; private set; }
        public long MusicianIdFK { get; private set; }
        public int StyleIdFK { get; private set; }
        public bool IsMainStyle { get; private set; }

        // Navigation properties
        public Musician Musician { get; private set; } = null!;
        public MusicStyle MusicianStyle { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private MusicianLikesStyle() { }

        // ── Static Factory Method ─────────────────────────────────────────
        public static MusicianLikesStyle Create(
            long musicianId,
            int styleId,
            bool isMainStyle)
        {
            var entity = new MusicianLikesStyle();

            entity.MusicianIdFK = musicianId;
            entity.StyleIdFK = styleId;
            entity.IsMainStyle = isMainStyle;
            return entity;
        }
    }
}
