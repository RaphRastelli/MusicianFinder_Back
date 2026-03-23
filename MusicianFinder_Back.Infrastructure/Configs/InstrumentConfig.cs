using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class InstrumentConfig : IEntityTypeConfiguration<Instrument>
    {
        public void Configure(EntityTypeBuilder<Instrument> builder)
        {
            // Table
            builder.ToTable("Instrument").HasData(
                new Instrument(1, "Chant masculin"),
                new Instrument(2, "Chant féminin"),
                new Instrument(3, "Guitare acoustique"),
                new Instrument(4, "Guitare électrique"),
                new Instrument(5, "Lap-Steel"),
                new Instrument(6, "Basse"),
                new Instrument(7, "Batterie"),
                new Instrument(8, "Percussions d’orchestre"),
                new Instrument(9, "Piano"),
                new Instrument(10, "Claviers/Synth"),
                new Instrument(11, "Clavecin"),
                new Instrument(12, "Orgue classique"),
                new Instrument(13, "Violon/Alto"),
                new Instrument(14, "Violoncelle"),
                new Instrument(15, "Contrebasse"),
                new Instrument(16, "Trompette"),
                new Instrument(17, "Trombone"),
                new Instrument(18, "Saxophone"),
                new Instrument(19, "Tuba"),
                new Instrument(20, "Clarinette"),
                new Instrument(21, "Flûte traversière"),
                new Instrument(22, "Hautbois/Basson"),
                new Instrument(23, "Cornemuse"),
                new Instrument(24, "Accordéon"),
                new Instrument(25, "Banjo"),
                new Instrument(26, "Mandoline"),
                new Instrument(27, "Luth"),
                new Instrument(28, "Autre instrument acoustique"),
                new Instrument(29, "Autre instrument électrique"),
                new Instrument(30, "Autre instrument électronique")
            );

            // Clé
            builder.HasKey(i => i.InstrumentId);
        }
    }
}
