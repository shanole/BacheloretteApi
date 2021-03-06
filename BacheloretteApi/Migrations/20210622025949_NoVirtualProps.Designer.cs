// <auto-generated />
using BacheloretteApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BacheloretteApi.Migrations
{
    [DbContext(typeof(BacheloretteApiContext))]
    [Migration("20210622025949_NoVirtualProps")]
    partial class NoVirtualProps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BacheloretteApi.Models.Bachelorette", b =>
                {
                    b.Property<int>("BacheloretteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Hometown")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Job")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Season")
                        .HasColumnType("int");

                    b.HasKey("BacheloretteId");

                    b.ToTable("Bachelorettes");

                    b.HasData(
                        new
                        {
                            BacheloretteId = 1,
                            Age = 30,
                            Hometown = "Renton, WA",
                            Job = "Marketing manager",
                            Name = "Katie Thurston",
                            Season = 17
                        });
                });

            modelBuilder.Entity("BacheloretteApi.Models.Contestant", b =>
                {
                    b.Property<int>("ContestantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BacheloretteId")
                        .HasColumnType("int");

                    b.Property<string>("Hometown")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsEliminated")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Job")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Season")
                        .HasColumnType("int");

                    b.HasKey("ContestantId");

                    b.ToTable("Contestants");

                    b.HasData(
                        new
                        {
                            ContestantId = 1,
                            Age = 27,
                            BacheloretteId = 1,
                            Hometown = "Edison, NJ",
                            IsEliminated = false,
                            Job = "Marketing Sales Representative",
                            Name = "Greg",
                            Season = 17
                        },
                        new
                        {
                            ContestantId = 2,
                            Age = 26,
                            BacheloretteId = 1,
                            Hometown = "San Diego, CA",
                            IsEliminated = false,
                            Job = "Insurance Agent",
                            Name = "Aaron",
                            Season = 17
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
