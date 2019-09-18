﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopOIL_Backend;

namespace TopOIL_Backend.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190918174657_AddedValidation")]
    partial class AddedValidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TopOIL_Backend.Models.OilField", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .HasMaxLength(60);

                    b.Property<int>("NumOfEmployees");

                    b.Property<int>("NumOfPumpjacks");

                    b.Property<int>("Production");

                    b.HasKey("ID");

                    b.ToTable("OilFields");
                });
#pragma warning restore 612, 618
        }
    }
}