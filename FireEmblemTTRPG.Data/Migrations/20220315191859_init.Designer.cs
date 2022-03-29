﻿// <auto-generated />
using FireEmblemTTRPG.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FireEmblemTTRPG.Data.Migrations
{
    [DbContext(typeof(FEContext))]
    [Migration("20220315191859_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FireEmblemTTRPG.Domain.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("FireEmblemTTRPG.Domain.Entities.CharacterClass", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("CharacterClass");
                });

            modelBuilder.Entity("FireEmblemTTRPG.Domain.Entities.CharacterWeapon", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "WeaponId");

                    b.HasIndex("WeaponId");

                    b.ToTable("CharacterWeapon");
                });

            modelBuilder.Entity("FireEmblemTTRPG.Domain.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaxLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("WeaponType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("FireEmblemTTRPG.Domain.Entities.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Crit")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Extra")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Hit")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Might")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Range")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("WeaponType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("FireEmblemTTRPG.Domain.Entities.Character", b =>
                {
                    b.OwnsOne("FireEmblemTTRPG.Domain.Entities.GrowthRate", "GrowthRate", b1 =>
                        {
                            b1.Property<int>("CharacterId")
                                .HasColumnType("int");

                            b1.Property<int>("DefGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("HPGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("LckGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("MagGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("ResGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("SklGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("SpdGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("StrGrowthRate")
                                .HasColumnType("int");

                            b1.HasKey("CharacterId");

                            b1.ToTable("Characters");

                            b1.WithOwner()
                                .HasForeignKey("CharacterId");
                        });

                    b.OwnsOne("FireEmblemTTRPG.Domain.Entities.Stat", "StatGrowth", b1 =>
                        {
                            b1.Property<int>("CharacterId")
                                .HasColumnType("int");

                            b1.Property<int>("Def")
                                .HasColumnType("int");

                            b1.Property<int>("HP")
                                .HasColumnType("int");

                            b1.Property<int>("Lck")
                                .HasColumnType("int");

                            b1.Property<int>("Mag")
                                .HasColumnType("int");

                            b1.Property<int>("Mov")
                                .HasColumnType("int");

                            b1.Property<int>("Res")
                                .HasColumnType("int");

                            b1.Property<int>("Skl")
                                .HasColumnType("int");

                            b1.Property<int>("Spd")
                                .HasColumnType("int");

                            b1.Property<int>("Str")
                                .HasColumnType("int");

                            b1.HasKey("CharacterId");

                            b1.ToTable("Characters");

                            b1.WithOwner()
                                .HasForeignKey("CharacterId");
                        });

                    b.Navigation("GrowthRate")
                        .IsRequired();

                    b.Navigation("StatGrowth")
                        .IsRequired();
                });

            modelBuilder.Entity("FireEmblemTTRPG.Domain.Entities.CharacterClass", b =>
                {
                    b.HasOne("FireEmblemTTRPG.Domain.Entities.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireEmblemTTRPG.Domain.Entities.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FireEmblemTTRPG.Domain.Entities.CharacterWeapon", b =>
                {
                    b.HasOne("FireEmblemTTRPG.Domain.Entities.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FireEmblemTTRPG.Domain.Entities.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FireEmblemTTRPG.Domain.Entities.Class", b =>
                {
                    b.OwnsOne("FireEmblemTTRPG.Domain.Entities.Stat", "BaseStat", b1 =>
                        {
                            b1.Property<int>("ClassId")
                                .HasColumnType("int");

                            b1.Property<int>("Def")
                                .HasColumnType("int");

                            b1.Property<int>("HP")
                                .HasColumnType("int");

                            b1.Property<int>("Lck")
                                .HasColumnType("int");

                            b1.Property<int>("Mag")
                                .HasColumnType("int");

                            b1.Property<int>("Mov")
                                .HasColumnType("int");

                            b1.Property<int>("Res")
                                .HasColumnType("int");

                            b1.Property<int>("Skl")
                                .HasColumnType("int");

                            b1.Property<int>("Spd")
                                .HasColumnType("int");

                            b1.Property<int>("Str")
                                .HasColumnType("int");

                            b1.HasKey("ClassId");

                            b1.ToTable("Classes");

                            b1.WithOwner()
                                .HasForeignKey("ClassId");
                        });

                    b.OwnsOne("FireEmblemTTRPG.Domain.Entities.GrowthRate", "GrowthRate", b1 =>
                        {
                            b1.Property<int>("ClassId")
                                .HasColumnType("int");

                            b1.Property<int>("DefGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("HPGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("LckGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("MagGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("ResGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("SklGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("SpdGrowthRate")
                                .HasColumnType("int");

                            b1.Property<int>("StrGrowthRate")
                                .HasColumnType("int");

                            b1.HasKey("ClassId");

                            b1.ToTable("Classes");

                            b1.WithOwner()
                                .HasForeignKey("ClassId");
                        });

                    b.OwnsOne("FireEmblemTTRPG.Domain.Entities.Stat", "MaxStat", b1 =>
                        {
                            b1.Property<int>("ClassId")
                                .HasColumnType("int");

                            b1.Property<int>("Def")
                                .HasColumnType("int");

                            b1.Property<int>("HP")
                                .HasColumnType("int");

                            b1.Property<int>("Lck")
                                .HasColumnType("int");

                            b1.Property<int>("Mag")
                                .HasColumnType("int");

                            b1.Property<int>("Mov")
                                .HasColumnType("int");

                            b1.Property<int>("Res")
                                .HasColumnType("int");

                            b1.Property<int>("Skl")
                                .HasColumnType("int");

                            b1.Property<int>("Spd")
                                .HasColumnType("int");

                            b1.Property<int>("Str")
                                .HasColumnType("int");

                            b1.HasKey("ClassId");

                            b1.ToTable("Classes");

                            b1.WithOwner()
                                .HasForeignKey("ClassId");
                        });

                    b.Navigation("BaseStat")
                        .IsRequired();

                    b.Navigation("GrowthRate")
                        .IsRequired();

                    b.Navigation("MaxStat")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
