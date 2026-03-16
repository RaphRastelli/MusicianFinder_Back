using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianLikesStyle
    {
        public Musician? Musician { get; private set; }
        public MusicStyle? MusicianStyle { get; private set; }
        public bool IsMainStyle { get; private set; }
    }
}
