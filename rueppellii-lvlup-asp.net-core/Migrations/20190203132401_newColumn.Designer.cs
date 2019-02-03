﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rueppellii_lvlup_asp.net_core.Data;

namespace rueppellii_lvlup_asp.net_core.Migrations
{
    [DbContext(typeof(LvlUpDbContext))]
    [Migration("20190203132401_newColumn")]
    partial class newColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("rueppellii_lvlup_asp.net_core.Models.Archetypes", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArchetypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Archetypes");
                });

            modelBuilder.Entity("rueppellii_lvlup_asp.net_core.Models.Badges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArchetypesId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("UsersId");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("testColumn")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.HasIndex("ArchetypesId");

                    b.HasIndex("UsersId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("rueppellii_lvlup_asp.net_core.Models.Levels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BadgesId");

                    b.Property<string>("Description");

                    b.Property<int?>("Level");

                    b.HasKey("Id");

                    b.HasIndex("BadgesId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("rueppellii_lvlup_asp.net_core.Models.Pitches", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Timetamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Pitches");
                });

            modelBuilder.Entity("rueppellii_lvlup_asp.net_core.Models.Users", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pic");

                    b.Property<string>("TokenAuth");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("rueppellii_lvlup_asp.net_core.Models.Badges", b =>
                {
                    b.HasOne("rueppellii_lvlup_asp.net_core.Models.Archetypes")
                        .WithMany("Badges")
                        .HasForeignKey("ArchetypesId");

                    b.HasOne("rueppellii_lvlup_asp.net_core.Models.Users")
                        .WithMany("Badges")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("rueppellii_lvlup_asp.net_core.Models.Levels", b =>
                {
                    b.HasOne("rueppellii_lvlup_asp.net_core.Models.Badges")
                        .WithMany("Levels")
                        .HasForeignKey("BadgesId");
                });
#pragma warning restore 612, 618
        }
    }
}
