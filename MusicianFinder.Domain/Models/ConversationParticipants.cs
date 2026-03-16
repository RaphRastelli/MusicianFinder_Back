using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class ConversationParticipants
    {
        public Conversation? Conversation { get; private set; }
        public Musician? Musician { get; private set; }
    }
}
