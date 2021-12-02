﻿// <auto-generated />
using GJJP8B_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GJJP8B_HFT_2021221.Data.Migrations
{
    [DbContext(typeof(CheeseContext))]
    [Migration("20211201145111_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GJJP8B_HFT_2021221.Models.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CheeseId")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CheeseId");

                    b.ToTable("buyers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheeseId = 1,
                            Money = 5500,
                            Name = "Test Ferenc"
                        },
                        new
                        {
                            Id = 2,
                            CheeseId = 2,
                            Money = 9800,
                            Name = "Teás K. Anna"
                        },
                        new
                        {
                            Id = 3,
                            CheeseId = 3,
                            Money = 6500,
                            Name = "Sigh Kyle"
                        });
                });

            modelBuilder.Entity("GJJP8B_HFT_2021221.Models.Cheese", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MilkId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("MilkId");

                    b.ToTable("cheeses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MilkId = 1,
                            Name = "Cheddar",
                            Price = 1500f
                        },
                        new
                        {
                            Id = 2,
                            MilkId = 2,
                            Name = "GoatCheese",
                            Price = 3500f
                        },
                        new
                        {
                            Id = 3,
                            MilkId = 1,
                            Name = "Maci",
                            Price = 850f
                        });
                });

            modelBuilder.Entity("GJJP8B_HFT_2021221.Models.Milk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("milks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CowMilk",
                            Price = 250f
                        },
                        new
                        {
                            Id = 2,
                            Name = "GoatMilk",
                            Price = 550f
                        });
                });

            modelBuilder.Entity("GJJP8B_HFT_2021221.Models.Buyer", b =>
                {
                    b.HasOne("GJJP8B_HFT_2021221.Models.Cheese", "Cheese")
                        .WithMany("Buyers")
                        .HasForeignKey("CheeseId")
                        .IsRequired();

                    b.Navigation("Cheese");
                });

            modelBuilder.Entity("GJJP8B_HFT_2021221.Models.Cheese", b =>
                {
                    b.HasOne("GJJP8B_HFT_2021221.Models.Milk", "Milk")
                        .WithMany("Cheeses")
                        .HasForeignKey("MilkId")
                        .IsRequired();

                    b.Navigation("Milk");
                });

            modelBuilder.Entity("GJJP8B_HFT_2021221.Models.Cheese", b =>
                {
                    b.Navigation("Buyers");
                });

            modelBuilder.Entity("GJJP8B_HFT_2021221.Models.Milk", b =>
                {
                    b.Navigation("Cheeses");
                });
#pragma warning restore 612, 618
        }
    }
}