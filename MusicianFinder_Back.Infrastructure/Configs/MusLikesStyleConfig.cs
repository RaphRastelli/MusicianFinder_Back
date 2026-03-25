using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class MusLikesStyleConfig : IEntityTypeConfiguration<MusicianLikesStyle>
    {
        public void Configure(EntityTypeBuilder<MusicianLikesStyle> builder)
        {
            // Table
            builder.ToTable("Musician_Styles");

            //
            builder.HasKey(ms => ms.MusicianStyleId)
                .HasName("PK_Musician_Styles");

            // Ajout de clef unique
            builder.HasIndex(ms => new { ms.MusicianIdFK, ms.StyleIdFK })
                .IsUnique()
                .HasDatabaseName("UX_Musician_Style_Unique");

            //
            builder.Property(ms => ms.MusicianStyleId)
                .ValueGeneratedOnAdd();

            builder.Property(ms => ms.IsMainStyle)
                .HasColumnName("Is_Main_Style")
                .IsRequired();

            //
            builder.HasOne(ms => ms.Musician)
                .WithMany(m => m.MM_MusicianMusicStyles)
                .HasForeignKey(ms => ms.MusicianIdFK)
                .IsRequired();

            builder.HasOne(ms => ms.MusicianStyle)
                .WithMany(s => s.MM_MusicianMusicStyles)
                .HasForeignKey(ms => ms.StyleIdFK)
                .IsRequired();
        }
    }
}
