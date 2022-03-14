﻿// <auto-generated />
using System;
using ConsoleApp3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleApp3.Migrations
{
    [DbContext(typeof(ProductionContext))]
    partial class ProductionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConsoleApp3.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ConsoleApp3.Models.GrowerAssignmentView", b =>
                {
                    b.Property<string>("CustomerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrowerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.ToTable("GrowerAssignmentView");
                });

            modelBuilder.Entity("ConsoleApp3.Models.OrderRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("FamilyCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("OrderRequirements");
                });

            modelBuilder.Entity("ConsoleApp3.Models.OrderRequirementDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("date");

                    b.Property<int>("OrderRequirementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderRequirementId");

                    b.ToTable("OrderRequirementDetails", (string)null);
                });

            modelBuilder.Entity("ConsoleApp3.Models.OrderRequirement", b =>
                {
                    b.HasOne("ConsoleApp3.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ConsoleApp3.Models.OrderRequirementDetail", b =>
                {
                    b.HasOne("ConsoleApp3.Models.OrderRequirement", "OrderRequirement")
                        .WithMany("OrderRequirementDetails")
                        .HasForeignKey("OrderRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderRequirement");
                });

            modelBuilder.Entity("ConsoleApp3.Models.OrderRequirement", b =>
                {
                    b.Navigation("OrderRequirementDetails");
                });
#pragma warning restore 612, 618
        }
    }
}