using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class Message
    {
        public int MessageId { get; private set; }
        public Conversation? Conversation { get; private set; }
        public Musician? SenderMusician { get; private set; }
        public string? Content { get; private set; }
        public bool IsRead { get; private set; }
        public bool IsSuppressed { get; private set; }
    }
}
