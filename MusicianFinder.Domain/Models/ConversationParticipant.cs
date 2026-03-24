using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class ConversationParticipant
    {
        public long ConvPartId { get; private set; }
        public long MusicianId { get; private set; }
        public long ConversationId { get; private set; }

        // Navigation properties
        public Conversation Conversation { get; private set; } = default!;
        public Musician Musician { get; private set; } = default!;

        // Ctor
        // Vide pour EntityFramework
        private ConversationParticipant() { }
    }
}
