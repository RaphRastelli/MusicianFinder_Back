using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class MusicStyleConfig : IEntityTypeConfiguration<MusicStyle>
    {
        public void Configure(EntityTypeBuilder<MusicStyle> builder)
        {
            // Table
            builder.ToTable("Music_Style").HasData(
                new MusicStyle(1, "Pop"),
                new MusicStyle(2, "Rock"),
                new MusicStyle(3, "Metal"),
                new MusicStyle(4, "Punk/Hardcore"),
                new MusicStyle(5, "Rock alternatif/post/indie"),
                new MusicStyle(6, "Folk"),
                new MusicStyle(7, "Chanson"),
                new MusicStyle(8, "Electro"),
                new MusicStyle(9, "Rap/Hip-Hop"),
                new MusicStyle(10, "Soul"),
                new MusicStyle(11, "Funk"),
                new MusicStyle(12, "Jeune Public"),
                new MusicStyle(13, "Jazz"),
                new MusicStyle(14, "Classique/Contemporain"),
                new MusicStyle(15, "Baroque/Ancien"),
                new MusicStyle(16, "Chorale"),
                new MusicStyle(17, "Reggae"),
                new MusicStyle(18, "Blues"),
                new MusicStyle(19, "Trad/World"),
                new MusicStyle(20, "Country"),
                new MusicStyle(21, "Fanfare"),
                new MusicStyle(22, "Cover")
            );

            // Clé
            builder.HasKey(m => m.StyleId);
        }
    }
}
