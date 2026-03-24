using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class Conversation
    {
        public long ConversationId { get; private set; }
        public DateTime DateCreation { get; private set; }
        public DateTime DateLastRead { get; private set; }

        // Properties from other models
        public ICollection<Musician> Musicians { get; set; } = [];

        // Ctor
        // Vide pour EntityFramework
        private Conversation() { }
    }
}
