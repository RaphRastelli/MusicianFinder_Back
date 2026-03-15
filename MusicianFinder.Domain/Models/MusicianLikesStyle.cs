using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianLikesStyle
    {
        public Musician? Musician { get; private set; }
        public IEnumerable<MusicStyle>? MusicStyleList { get; private set; }
        public MusicStyle? IsMainStyle { get; private set; }
    }
}
