﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WeatherExcelStorage.Core.Data;

#nullable disable

namespace WeatherExcelStorage.Core.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WeatherExcelStorage.Core.Data.Entities.WeatherReportEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AirPressure")
                        .HasColumnType("integer")
                        .HasColumnName("pressure");

                    b.Property<decimal>("AirTemperature")
                        .HasColumnType("numeric")
                        .HasColumnName("temperature");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("datetime");

                    b.Property<decimal>("DewPoint")
                        .HasColumnType("numeric")
                        .HasColumnName("dew");

                    b.Property<int?>("HorizontalSight")
                        .HasColumnType("integer")
                        .HasColumnName("horizontal_sight");

                    b.Property<int>("Humidity")
                        .HasColumnType("integer")
                        .HasColumnName("humidity");

                    b.Property<int>("LowOvercastPoint")
                        .HasColumnType("integer")
                        .HasColumnName("low_overcast_point");

                    b.Property<int?>("Overcast")
                        .HasColumnType("integer")
                        .HasColumnName("overcast");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("WeatherConditions")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int[]>("WindDirection")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("wind_direction");

                    b.Property<int>("WindSpeed")
                        .HasColumnType("integer")
                        .HasColumnName("wind_speed");

                    b.HasKey("Id");

                    b.HasIndex("DateTime")
                        .IsUnique();

                    b.HasIndex("CreatedAt", "UpdatedAt");

                    b.ToTable("reports");
                });
#pragma warning restore 612, 618
        }
    }
}
