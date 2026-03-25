using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                /*new MusicStyle(1, "Pop"),
                new MusicStyle(2, "Rock"),
                new MusicStyle(3, "Metal"),
                new MusicStyle(4, "Punk/Hardcore"),
                new MusicStyle(5, "Rock alternatif"),
                new MusicStyle(6, "Folk"),
                new MusicStyle(7, "Chanson"),
                new MusicStyle(8, "Electro"),
                new MusicStyle(9, "Hip-Hop"),
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
                new MusicStyle(22, "Cover"),
                new MusicStyle(23, "Rap")*/
                new MusicStyle(1, "Chanson"),
                new MusicStyle(2, "Pop"),
                new MusicStyle(3, "Rock / Rock alternatif"),
                new MusicStyle(4, "Metal"),
                new MusicStyle(5, "Punk"),
                new MusicStyle(6, "Folk / Acoustique"),
                new MusicStyle(7, "Jazz"),
                new MusicStyle(8, "Blues"),
                new MusicStyle(9, "Soul / R&B / Funk"),
                new MusicStyle(10, "Rap / Hip‑Hop / Slam"),
                new MusicStyle(11, "Electro / EDM / Ambient"),
                new MusicStyle(12, "Classique / Contemporain"),
                new MusicStyle(13, "Baroque / Ancien"),
                new MusicStyle(14, "Chorale / Voix d'ensemble"),
                new MusicStyle(15, "Trad / World"),
                new MusicStyle(16, "Reggae / Ska"),
                new MusicStyle(17, "Country"),
                new MusicStyle(18, "Jeune Public"),
                new MusicStyle(19, "Covers"),
                new MusicStyle(20, "Expérimental / Avant‑garde"),
                new MusicStyle(21, "Fanfare")
            );

            // Faire la config quand meme, non ? Tu penses pas ?

            // Clé
            builder.HasKey(m => m.StyleId);
        }
    }
}
