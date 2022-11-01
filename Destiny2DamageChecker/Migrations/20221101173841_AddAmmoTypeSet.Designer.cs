﻿// <auto-generated />
using System;
using Destiny2DataLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    [DbContext(typeof(Destiny2DataContext))]
    [Migration("20221101173841_AddAmmoTypeSet")]
    partial class AddAmmoTypeSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Destiny2DataLibrary.Models.ActivationStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PerkId")
                        .HasColumnType("integer");

                    b.Property<int>("PveDamageBuffPercent")
                        .HasColumnType("integer");

                    b.Property<int>("PveRapidFirePercent")
                        .HasColumnType("integer");

                    b.Property<int>("PvpDamageBuffPercent")
                        .HasColumnType("integer");

                    b.Property<int>("PvpRapidFireBuffPercent")
                        .HasColumnType("integer");

                    b.Property<int>("StepNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PerkId");

                    b.ToTable("ActivationSteps");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.AmmoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AmmoTypes");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.Archetype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AmmoTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("RoundsPerMinute")
                        .HasColumnType("integer");

                    b.Property<int?>("ShotDamageId")
                        .HasColumnType("integer");

                    b.Property<int>("WeaponTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AmmoTypeId");

                    b.HasIndex("ShotDamageId");

                    b.HasIndex("WeaponTypeId");

                    b.ToTable("Archetypes");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.Perk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActivationStepsAmount")
                        .HasColumnType("integer");

                    b.Property<int?>("ArchetypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdvanced")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArchetypeId");

                    b.ToTable("Perks");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.ShotDamage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("PveBulletDamage")
                        .HasColumnType("integer");

                    b.Property<int?>("PvePrecisionBulletDamage")
                        .HasColumnType("integer");

                    b.Property<int?>("PvpBulletDamage")
                        .HasColumnType("integer");

                    b.Property<int?>("PvpPrecisionBulletDamage")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ShotsDamage");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.WeaponType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WeaponTypes");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.ActivationStep", b =>
                {
                    b.HasOne("Destiny2DataLibrary.Models.Perk", "Perk")
                        .WithMany("ActivationSteps")
                        .HasForeignKey("PerkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perk");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.Archetype", b =>
                {
                    b.HasOne("Destiny2DataLibrary.Models.AmmoType", "AmmoType")
                        .WithMany()
                        .HasForeignKey("AmmoTypeId");

                    b.HasOne("Destiny2DataLibrary.Models.ShotDamage", "ShotDamage")
                        .WithMany()
                        .HasForeignKey("ShotDamageId");

                    b.HasOne("Destiny2DataLibrary.Models.WeaponType", "WeaponType")
                        .WithMany()
                        .HasForeignKey("WeaponTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AmmoType");

                    b.Navigation("ShotDamage");

                    b.Navigation("WeaponType");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.Perk", b =>
                {
                    b.HasOne("Destiny2DataLibrary.Models.Archetype", null)
                        .WithMany("Perks")
                        .HasForeignKey("ArchetypeId");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.Archetype", b =>
                {
                    b.Navigation("Perks");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.Perk", b =>
                {
                    b.Navigation("ActivationSteps");
                });
#pragma warning restore 612, 618
        }
    }
}
