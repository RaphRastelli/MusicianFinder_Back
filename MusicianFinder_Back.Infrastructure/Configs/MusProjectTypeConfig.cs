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
            builder.ToTable("Musician_Project_Types");

            builder.HasKey(mp => mp.MusProjectId)
                .HasName("PK_Musician_Project_Types");

            builder.Property(mp => mp.MusProjectId)
                .ValueGeneratedOnAdd();

            builder.HasOne(ms => ms.Musician)
                .WithMany()
                .HasForeignKey(ms => ms.MusicianId)
                .IsRequired();

            builder.HasOne(ms => ms.ProjectType)
                .WithMany()
                .HasForeignKey(ms => ms.ProjectTypeId)
                .IsRequired();
        }
    }
}
