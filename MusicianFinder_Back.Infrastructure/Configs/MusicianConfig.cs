using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Enums;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class MusicianConfig : IEntityTypeConfiguration<Musician>
    {
        public void Configure(EntityTypeBuilder<Musician> builder)
        {
            // Table
            builder.ToTable("Musician");

            // Clé
            builder.HasKey(m => m.Id)
                .HasName("PK_Musician")
                .IsClustered();

            // Colonnes
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Username)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(m => m.Email)
                .HasMaxLength(320)
                .IsUnicode()
                .IsRequired();

            builder.Property(m => m.PasswordHash)
                .HasColumnName("Password_hashed")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.Description)
                .HasMaxLength(5000)
                .IsUnicode()
                .IsRequired(false);

            builder.Property(m => m.Role)
                .HasConversion<string>()
                .HasDefaultValue(MusicianRoleEnum.User)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(m => m.Ability)
                .HasConversion<int?>()
                .IsRequired(false);

            builder.Property(m => m.Availability)
                .HasConversion<int?>()
                .IsRequired(false);

            builder.Property(m => m.BgColor)
                .HasDefaultValue("#FFFFFF")
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(m => m.FontFamily)
                .HasDefaultValue("SourceSans3")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.TextColor)
                .HasDefaultValue("#052d3d")
                .HasMaxLength(7)
                .IsUnicode()
                .IsRequired();

            // Index
            builder.HasIndex(m => m.Email)
                .IsUnique()
                .HasDatabaseName("IX_Musicians__Email");


            // Config de la Many to Many
            // Permet d'avoir les props de navigation simplifié !
            builder.HasMany(m => m.MusicStyles)
                .WithMany(ms => ms.Musicians)
                .UsingEntity<MusicianLikesStyle>();

            builder.HasMany(m => m.Locations)
                .WithMany(ml => ml.Musicians)
                .UsingEntity<MusicianLocation>();

            builder.HasMany(m => m.Instruments)
                .WithMany(i => i.Musicians)
                .UsingEntity<MusicianPlaysInstrument>();

            builder.HasMany(m => m.ProjectTypes)
                .WithMany(p => p.Musicians)
                .UsingEntity<MusicianProjectType>();

        }
    }
}
