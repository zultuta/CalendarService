﻿// <auto-generated />
using System;
using CalendarService.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalendarService.Infrastructure.Migrations
{
    [DbContext(typeof(CalendarServiceDbContext))]
    [Migration("20211212122728_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("CalendarService.Core.Entities.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("EventOrganizer")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("CalendarService.Core.Entities.EventMembers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<long>("EventId")
                        .HasMaxLength(100)
                        .HasColumnType("bigint")
                        .HasColumnName("EventId");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("Name");

                    b.ToTable("Event_Members", "CalendarService");
                });

            modelBuilder.Entity("CalendarService.Core.Entities.EventMembers", b =>
                {
                    b.HasOne("CalendarService.Core.Entities.Event", "Event")
                        .WithMany("EventMembers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("CalendarService.Core.Entities.Event", b =>
                {
                    b.Navigation("EventMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
