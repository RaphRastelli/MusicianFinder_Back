using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class MusicianPlaysInstrument
    {
        public int MusInstrumentId { get; private set; }
        public long MusicianIdFK { get; private set; }
        public int InstrumentIdFK { get; private set; }
        public bool IsMainInstrument { get; private set; }

        // Navigation properties
        public Musician Musician { get; private set; } = null!;
        public Instrument Instrument { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private MusicianPlaysInstrument() { }

        // ── Static Factory Method ─────────────────────────────────────────
        // Seule façon autorisée de créer une instance depuis l'extérieur.
        // Puisque cette méthode EST dans la classe, elle peut accéder
        // au constructeur private et aux propriétés private set.
        public static MusicianPlaysInstrument Create(
            long musicianId,
            int instrumentId,
            bool isMainInstrument)
        {
            // On appelle le constructeur private — accessible car on est dans la classe
            var entity = new MusicianPlaysInstrument();

            // On assigne les propriétés private set — accessible car on est dans la classe
            entity.MusicianIdFK = musicianId;
            entity.InstrumentIdFK = instrumentId;
            entity.IsMainInstrument = isMainInstrument;

            return entity;
        }
    }
}
