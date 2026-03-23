using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            // Table
            builder.ToTable("Location").HasData(
                new Location(1, "Bruxelles"),
                new Location(2, "Brabant"),
                new Location(3, "Namur (ville)"),
                new Location(4, "Namur (province)"),
                new Location(5, "Liège (ville)"),
                new Location(6, "Liège (province)"),
                new Location(7, "Hainaut/Mons"),
                new Location(8, "Hainaut/Charleroi"),
                new Location(9, "Luxembourg"),
                new Location(10, "Anvers (ville)"),
                new Location(11, "Anvers (province)"),
                new Location(12, "Limbourg"),
                new Location(13, "Flandre Orientale"),
                new Location(14, "Flandre Occidentale")
            );

            // Clé
            builder.HasKey(l => l.LocationId);
        }
    }
}
