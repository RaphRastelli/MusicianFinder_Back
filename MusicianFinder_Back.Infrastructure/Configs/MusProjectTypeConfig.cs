using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class MusProjectTypeConfig : IEntityTypeConfiguration<MusicianProjectType>
    {
        public void Configure(EntityTypeBuilder<MusicianProjectType> builder)
        {
            //
            builder.ToTable("Musician_Project_Types");

            //
            builder.HasKey(mp => mp.MusProjectId)
                .HasName("PK_Musician_Project_Types");

            // Ajout de clef unique
            builder.HasIndex(mp => new { mp.MusicianIdFK, mp.ProjectTypeIdFK })
                .IsUnique()
                .HasDatabaseName("UX_Musician_Project_Unique");

            //
            builder.Property(mp => mp.MusProjectId)
                .ValueGeneratedOnAdd();

            //
            builder.HasOne(ms => ms.Musician)
                .WithMany(m => m.MM_MusicianProjectTypes)
                .HasForeignKey(ms => ms.MusicianIdFK)
                .IsRequired();

            builder.HasOne(ms => ms.ProjectType)
                .WithMany(s => s.MM_MusicianProjectTypes)
                .HasForeignKey(ms => ms.ProjectTypeIdFK)
                .IsRequired();
        }
    }
}
