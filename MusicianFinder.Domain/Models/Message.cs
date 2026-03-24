using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class Message
    {
        public long MessageId { get; private set; }
        public Conversation Conversation { get; private set; } = null!;
        public Musician SenderMusician { get; private set; } = null!;
        public string Content { get; private set; } = null!;
        public bool IsRead { get; private set; }
        public bool IsSuppressed { get; private set; }

        // Ctor
        // Vide pour EntityFramework
        private Message() { }
    }
}
