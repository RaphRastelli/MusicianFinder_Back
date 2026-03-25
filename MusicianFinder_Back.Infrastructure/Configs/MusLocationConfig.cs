using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class MusLocationConfig : IEntityTypeConfiguration<MusicianLocation>
    {
        public void Configure(EntityTypeBuilder<MusicianLocation> builder)
        {
            //
            builder.ToTable("Musician_Locations");

            //
            builder.HasKey(ml => ml.MusicianLocId)
                .HasName("PK_Musician_Locations");

            // Ajout de clef unique
            builder.HasIndex(ml => new { ml.MusicianIdFK, ml.LocationIdFK })
                .IsUnique()
                .HasDatabaseName("UX_Musician_Location_Unique");
            //
            builder.Property(ml => ml.MusicianLocId)
                .ValueGeneratedOnAdd();

            //
            builder.HasOne(ml => ml.Musician)
                .WithMany(m => m.MM_MusicianLocations)
                .HasForeignKey(ml => ml.MusicianIdFK)
                .IsRequired();

            builder.HasOne(ml => ml.Location)
                .WithMany(l => l.MM_MusicianLocations)
                .HasForeignKey(ml => ml.LocationIdFK)
                .IsRequired();

        }
    }
}
