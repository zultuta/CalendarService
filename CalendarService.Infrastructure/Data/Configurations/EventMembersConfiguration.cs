using CalendarService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarService.Infrastructure.Data.Configurations
{
    public class EventMembersConfiguration : IEntityTypeConfiguration<EventMembers>
    {
        public void Configure(EntityTypeBuilder<EventMembers> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(t => t.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(t => t.EventId).HasColumnName("EventId").HasMaxLength(100);


            builder.HasOne(t => t.Event)
                .WithMany(t => t.EventMembers)
                .HasForeignKey(t => t.EventId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.Name).IsUnique(false);

            builder.ToTable("Event_Members", "CalendarService");
        }
    }
}
