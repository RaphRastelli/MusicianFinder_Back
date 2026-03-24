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
            builder.ToTable("Musician_Locations");

            builder.HasKey(ml => ml.MusicianLocId)
                .HasName("PK_Musician_Locations");

            builder.Property(ml => ml.MusicianLocId)
                .ValueGeneratedOnAdd();

            builder.HasOne(ml => ml.Musician)
                .WithMany(m => m.Locations)
                .HasForeignKey(ml => ml.MusicianIdFK)
                .IsRequired();

            builder.HasOne(ml => ml.Location)
                .WithMany(l => l.Musicians)
                .HasForeignKey(ml => ml.LocationIdFK)
                .IsRequired();

        }
    }
}
