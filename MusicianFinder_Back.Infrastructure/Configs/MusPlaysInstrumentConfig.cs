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

            //
            builder.Property(mi => mi.MusInstrumentId)
                .ValueGeneratedOnAdd();

            builder.Property(mi => mi.IsMainInstrument)
                .HasColumnName("Is_Main_Instrument")
                .IsRequired();

            //
            builder.HasOne(mi => mi.Musician)
                .WithMany(m => m.Instruments)
                .HasForeignKey(mi => mi.MusicianIdFK)
                .IsRequired();

            builder.HasOne(mi => mi.Instrument)
                .WithMany(i => i.Musicians)
                .HasForeignKey(mi => mi.InstrumentIdFK)
                .IsRequired();
        }
    }
}
