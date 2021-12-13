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
    public class EventConfiguration
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(t => t.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(t => t.Time).HasColumnName("Time").HasMaxLength(100);
            builder.Property(t => t.Location).HasColumnName("Location").HasMaxLength(100).IsRequired();
            builder.Property(t => t.EventOrganizer).HasColumnName("EventOrganizer").HasMaxLength(150).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique(false);
            builder.HasIndex(x => x.Location).IsUnique(false);
            builder.HasIndex(x => x.EventOrganizer).IsUnique(false);

            builder.ToTable("Event", "CalendarService");
        }
    }
}
