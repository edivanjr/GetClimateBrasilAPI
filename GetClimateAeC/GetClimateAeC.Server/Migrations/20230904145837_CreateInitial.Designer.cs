﻿// <auto-generated />
using System;
using GetClimateAeC.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GetClimateAeC.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230904145837_CreateInitial")]
    partial class CreateInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GetClimateAeC.Shared.AirportClimate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Atmospheric_Pressure")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "pressao_atmosferica");

                    b.Property<string>("Code_Icao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "codigo_icao");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "condicao");

                    b.Property<string>("Condition_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "condicao_desc");

                    b.Property<int>("Moisture")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "umidade");

                    b.Property<int>("Temperature")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "temp");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "atualizado_em");

                    b.Property<string>("Visibility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "visibilidade");

                    b.Property<int>("Wind")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "vento");

                    b.Property<int>("Wind_Direction")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "direcao_vento");

                    b.HasKey("Id");

                    b.ToTable("AirportClimate", (string)null);
                });

            modelBuilder.Entity("GetClimateAeC.Shared.AirportCodes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Airport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkAirportClimateBrasilAPI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkAirportClimateLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AirportCodes", (string)null);
                });

            modelBuilder.Entity("GetClimateAeC.Shared.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city_name")
                        .HasAnnotation("Relational:JsonPropertyName", "nome");

                    b.Property<int>("Id_City")
                        .HasColumnType("int")
                        .HasColumnName("id_city")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("state")
                        .HasAnnotation("Relational:JsonPropertyName", "estado");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("GetClimateAeC.Shared.CityClimate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "cidade");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "estado");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "atualizado_em");

                    b.HasKey("Id");

                    b.ToTable("CityClimate", (string)null);
                });

            modelBuilder.Entity("GetClimateAeC.Shared.CityClimateArray", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "condicao");

                    b.Property<string>("Condition_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "condicao_desc");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "data");

                    b.Property<int>("Max")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "max");

                    b.Property<int>("Min")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "min");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Uv_Index")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "indice_uv");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("CityClimateArray", (string)null);
                });

            modelBuilder.Entity("GetClimateAeC.Shared.ErrorLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ErrorLog", (string)null);
                });

            modelBuilder.Entity("GetClimateAeC.Shared.CityClimateArray", b =>
                {
                    b.HasOne("GetClimateAeC.Shared.CityClimate", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });
#pragma warning restore 612, 618
        }
    }
}
