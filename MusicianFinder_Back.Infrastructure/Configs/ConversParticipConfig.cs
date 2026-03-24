using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicianFinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicianFinder_Back.Infrastructure.Configs
{
    internal class ConversParticipConfig : IEntityTypeConfiguration<ConversationParticipant>
    {
        public void Configure(EntityTypeBuilder<ConversationParticipant> builder)
        {
            // Table
            builder.ToTable("Convers_Particip");

            //
            builder.HasKey(cp => cp.ConvPartId)
                .HasName("PK_ConversParticip");

            //
            builder.Property(cp => cp.ConvPartId)
                .ValueGeneratedOnAdd();

            // Foreign keys
            builder.HasOne(cp => cp.Conversation)
                .WithMany()
                .HasForeignKey(cp => cp.ConversationId)
                .IsRequired();

            builder.HasOne(cp => cp.Musician)
                .WithMany()
                .HasForeignKey(cp => cp.MusicianId)
                .IsRequired();
        }
    }
}
