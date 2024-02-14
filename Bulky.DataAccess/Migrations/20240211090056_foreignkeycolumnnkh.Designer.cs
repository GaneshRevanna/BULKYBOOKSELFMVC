﻿// <auto-generated />
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240211090056_foreignkeycolumnnkh")]
    partial class foreignkeycolumnnkh
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.models.Catogiries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("displayorder")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Catogiries");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Name = "Sowmya",
                            displayorder = 1
                        },
                        new
                        {
                            id = 2,
                            Name = "Ganesh",
                            displayorder = 2
                        },
                        new
                        {
                            id = 3,
                            Name = "prf",
                            displayorder = 3
                        });
                });

            modelBuilder.Entity("Bulky.models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "good book",
                            ISBN = "hsv",
                            ListPrice = 1000.0,
                            Price = 20.0,
                            Price100 = 2000.0,
                            Price50 = 1000.0,
                            Title = "Best Of world",
                            author = "Ansi"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Fantastic book",
                            ISBN = "hsv",
                            ListPrice = 1000.0,
                            Price = 20.0,
                            Price100 = 2000.0,
                            Price50 = 1000.0,
                            Title = "Best Of Nature",
                            author = "Ramakrishna"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Crazy Book",
                            ISBN = "hsv",
                            ListPrice = 1000.0,
                            Price = 20.0,
                            Price100 = 2000.0,
                            Price50 = 1000.0,
                            Title = "Best Of earth",
                            author = "krishna"
                        });
                });

            modelBuilder.Entity("Bulky.models.Product", b =>
                {
                    b.HasOne("Bulky.models.Catogiries", "Catogiries")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catogiries");
                });
#pragma warning restore 612, 618
        }
    }
}
