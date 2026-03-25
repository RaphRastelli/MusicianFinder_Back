using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class MusPlaysInstrumentConfig : IEntityTypeConfiguration<MusicianPlaysInstrument>
    {
        public void Configure(EntityTypeBuilder<MusicianPlaysInstrument> builder)
        {
            // Table
            builder.ToTable("Musician_Instruments");

            //
            builder.HasKey(mi => mi.MusInstrumentId)
                .HasName("PK_Musician_Instruments");

            // Ajout de clef unique
            builder.HasIndex(mi => new { mi.MusicianIdFK, mi.InstrumentIdFK })
                .IsUnique()
                .HasDatabaseName("UX_Musician_Instrument_Unique");

            //
            builder.Property(mi => mi.MusInstrumentId)
                .ValueGeneratedOnAdd();

            builder.Property(mi => mi.IsMainInstrument)
                .HasColumnName("Is_Main_Instrument")
                .IsRequired();

            //
            builder.HasOne(mi => mi.Musician)
                .WithMany(m => m.MM_MusicianInstruments)
                .HasForeignKey(mi => mi.MusicianIdFK)
                .IsRequired();

            builder.HasOne(mi => mi.Instrument)
                .WithMany(i => i.MM_MusicianInstruments)
                .HasForeignKey(mi => mi.InstrumentIdFK)
                .IsRequired();
        }
    }
}
