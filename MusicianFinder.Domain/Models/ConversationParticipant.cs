using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class ConversationParticipant
    {
        public long MusicianId { get; private set; }
        public long MessageId { get; private set; }

        // Navigation properties
        public Conversation Conversation { get; private set; } = null!;
        public Musician Musician { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private ConversationParticipant() { }
    }
}
