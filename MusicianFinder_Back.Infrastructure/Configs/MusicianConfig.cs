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

            // Colonnes (TODO à compléter)
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
                .IsUnicode();

            builder.Property(m => m.Role)
                .HasConversion<string>()
                .HasDefaultValue(MusicianRoleEnum.User)
                .HasMaxLength(10)
                .HasSentinel(0)
                .IsRequired();

            builder.Property(m => m.Ability)
                .HasConversion<string>()
                .HasMaxLength(15)
                .HasSentinel(0);

            builder.Property(m => m.Availability)
                .HasConversion<string>()
                .HasMaxLength(25)
                .HasSentinel(0);

            builder.Property(m => m.BgColor)
                .HasDefaultValue("#FFFFFF")
                .HasMaxLength(10)
                .IsUnicode()
                .IsRequired();

            builder.Property(m => m.FontFamily)
                .HasDefaultValue("Arial")
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder.Property(m => m.TextColor)
                .HasDefaultValue("#000000")
                .HasMaxLength(10)
                .IsUnicode()
                .IsRequired();

            // Index
            builder.HasIndex(m => m.Email)
                .IsUnique()
                .HasDatabaseName("IX_Misicians__Email");
        }
    }
}
