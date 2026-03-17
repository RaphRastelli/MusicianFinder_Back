using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class ConversationParticipant
    {
        public Conversation Conversation { get; private set; } = null!;
        public Musician Musician { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private ConversationParticipant() { }
    }
}
