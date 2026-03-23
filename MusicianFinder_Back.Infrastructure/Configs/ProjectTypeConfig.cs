using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class ProjectTypeConfig : IEntityTypeConfiguration<ProjectType>
    {
        public void Configure(EntityTypeBuilder<ProjectType> builder)
        {
            // Table
            builder.ToTable("Project_Type").HasData(
                new ProjectType(1, "LongTermeSansGarantie"),
                new ProjectType(2, "LongTermAvecGarantie"),
                new ProjectType(3, "PonctuelSansGarantie"),
                new ProjectType(4, "PonctuelAvecGarantie"),
                new ProjectType(5, "Cours")
            );

            // Clé
            builder.HasKey(p => p.ProjectTypeId);
        }

    }
}
