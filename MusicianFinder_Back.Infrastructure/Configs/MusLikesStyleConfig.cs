using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
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

            //
            builder.Property(ms => ms.MusicianStyleId)
                .ValueGeneratedOnAdd();

            builder.Property(ms => ms.IsMainStyle)
                .HasColumnName("Is_Main_Style")
                .IsRequired();

            //
            builder.HasOne(ms => ms.Musician)
                .WithMany(m => m.MusicStyles)
                .HasForeignKey(ms => ms.MusicianIdFK)
                .IsRequired();

            builder.HasOne(ms => ms.MusicianStyle)
                .WithMany(s => s.Musicians)
                .HasForeignKey(ms => ms.StyleIdFK)
                .IsRequired();

        }
    }
}
