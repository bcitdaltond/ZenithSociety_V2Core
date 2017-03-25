using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ZenithSocietyCore.Models;

namespace ZenithSocietyCore.Migrations
{
    [DbContext(typeof(ZenithContext))]
    [Migration("20170323225121_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("ZenithSocietyCore.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("ActivityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("ZenithSocietyCore.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("End");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("Start");

                    b.HasKey("EventId");

                    b.HasIndex("ActivityId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ZenithSocietyCore.Models.Event", b =>
                {
                    b.HasOne("ZenithSocietyCore.Models.Activity", "Activity")
                        .WithMany("Events")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
