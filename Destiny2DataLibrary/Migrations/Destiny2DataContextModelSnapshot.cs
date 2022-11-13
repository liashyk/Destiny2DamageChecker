﻿// <auto-generated />
using System;
using Destiny2DataLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Destiny2DataLibrary.Migrations
{
    [DbContext(typeof(Destiny2DataContext))]
    partial class Destiny2DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ArchetypePerk", b =>
                {
                    b.Property<int>("ArchetypesId")
                        .HasColumnType("integer");

                    b.Property<int>("PerksId")
                        .HasColumnType("integer");

                    b.HasKey("ArchetypesId", "PerksId");

                    b.HasIndex("PerksId");

                    b.ToTable("ArchetypePerk");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.AmmoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

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

                    b.Property<int?>("BurstStatsId")
                        .HasColumnType("integer");

                    b.Property<double>("FramesBetweenShots")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsBurst")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("RoundsPerMinute")
                        .HasColumnType("double precision");

                    b.Property<int>("ShotDamageId")
                        .HasColumnType("integer");

                    b.Property<int>("WeaponTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AmmoTypeId");

                    b.HasIndex("BurstStatsId");

                    b.HasIndex("ShotDamageId");

                    b.HasIndex("WeaponTypeId");

                    b.ToTable("Archetypes");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.BuffCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BuffCategories");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.BuffStack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("PerkId")
                        .HasColumnType("integer");

                    b.Property<double>("PveDamageBuffPercent")
                        .HasColumnType("double precision");

                    b.Property<double>("PveRapidFirePercent")
                        .HasColumnType("double precision");

                    b.Property<double>("PvpDamageBuffPercent")
                        .HasColumnType("double precision");

                    b.Property<double>("PvpRapidFireBuffPercent")
                        .HasColumnType("double precision");

                    b.Property<int?>("ReloadStatId")
                        .HasColumnType("integer");

                    b.Property<int>("StepNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PerkId");

                    b.HasIndex("ReloadStatId");

                    b.ToTable("BuffStacks");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.BurstStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BulletsInBurst")
                        .HasColumnType("integer");

                    b.Property<int>("FramesPerBurstt")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BurstStats");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.DamageBuff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuffCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("BuffCategoryId");

                    b.ToTable("DamageBuffs");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.Perk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActivationStepsAmount")
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

                    b.ToTable("Perks");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.ReloadStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("a")
                        .HasColumnType("double precision");

                    b.Property<double>("b")
                        .HasColumnType("double precision");

                    b.Property<double>("c")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("ReloadStats");
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
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("ReloadStatsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReloadStatsId");

                    b.ToTable("WeaponTypes");
                });

            modelBuilder.Entity("ArchetypePerk", b =>
                {
                    b.HasOne("Destiny2DataLibrary.Models.Archetype", null)
                        .WithMany()
                        .HasForeignKey("ArchetypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Destiny2DataLibrary.Models.Perk", null)
                        .WithMany()
                        .HasForeignKey("PerksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.Archetype", b =>
                {
                    b.HasOne("Destiny2DataLibrary.Models.AmmoType", "AmmoType")
                        .WithMany()
                        .HasForeignKey("AmmoTypeId");

                    b.HasOne("Destiny2DataLibrary.Models.BurstStats", "BurstStats")
                        .WithMany()
                        .HasForeignKey("BurstStatsId");

                    b.HasOne("Destiny2DataLibrary.Models.ShotDamage", "ShotDamage")
                        .WithMany()
                        .HasForeignKey("ShotDamageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Destiny2DataLibrary.Models.WeaponType", "WeaponType")
                        .WithMany()
                        .HasForeignKey("WeaponTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AmmoType");

                    b.Navigation("BurstStats");

                    b.Navigation("ShotDamage");

                    b.Navigation("WeaponType");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.BuffStack", b =>
                {
                    b.HasOne("Destiny2DataLibrary.Models.Perk", null)
                        .WithMany("BuffStacks")
                        .HasForeignKey("PerkId");

                    b.HasOne("Destiny2DataLibrary.Models.ReloadStat", "ReloadStat")
                        .WithMany()
                        .HasForeignKey("ReloadStatId");

                    b.Navigation("ReloadStat");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.DamageBuff", b =>
                {
                    b.HasOne("Destiny2DataLibrary.Models.BuffCategory", "BuffCategory")
                        .WithMany()
                        .HasForeignKey("BuffCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuffCategory");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.WeaponType", b =>
                {
                    b.HasOne("Destiny2DataLibrary.Models.ReloadStat", "ReloadStats")
                        .WithMany()
                        .HasForeignKey("ReloadStatsId");

                    b.Navigation("ReloadStats");
                });

            modelBuilder.Entity("Destiny2DataLibrary.Models.Perk", b =>
                {
                    b.Navigation("BuffStacks");
                });
#pragma warning restore 612, 618
        }
    }
}
