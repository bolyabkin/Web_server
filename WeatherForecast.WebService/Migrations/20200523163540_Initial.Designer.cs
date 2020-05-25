﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForecast.InfrastructureServices.Gateways.Database;

namespace WeatherForecast.WebService.Migrations
{
    [DbContext(typeof(ForecastContext))]
    [Migration("20200523163540_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("WeatherForecast.DomainObjects.Forecast", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndForecast")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxTemperature")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinTemperature")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StartForecast")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeForecast")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Forecasts");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Date = "10.02.2017 17:59:00",
                            EndForecast = "11.02.2017 09:00:00 ",
                            MaxTemperature = -2,
                            MinTemperature = -4,
                            StartForecast = "10.02.2017 21:00:00",
                            TypeForecast = "двенадцатичасовой прогноз"
                        },
                        new
                        {
                            Id = 2L,
                            Date = "29.06.2018 06:02:00",
                            EndForecast = "29.06.2018 12:00:00",
                            MaxTemperature = 29,
                            MinTemperature = 27,
                            StartForecast = "29.06.2018 09:00:00",
                            TypeForecast = "трехчасовой прогноз"
                        },
                        new
                        {
                            Id = 3L,
                            Date = "26.06.2018 05:54:00",
                            EndForecast = "26.06.2018 12:00:00",
                            MaxTemperature = 26,
                            MinTemperature = 24,
                            StartForecast = "26.06.2018 09:00:00",
                            TypeForecast = "трехчасовой прогноз"
                        },
                        new
                        {
                            Id = 4L,
                            Date = "28.06.2018 05:35:00",
                            EndForecast = "28.06.2018 12:00:00",
                            MaxTemperature = 29,
                            MinTemperature = 27,
                            StartForecast = "28.06.2018 09:00:00",
                            TypeForecast = "трехчасовой прогноз"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
