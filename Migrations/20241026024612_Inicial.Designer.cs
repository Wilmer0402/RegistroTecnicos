﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicos.DAL;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241026024612_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RegistroTecnicos.Models.Articulos", b =>
                {
                    b.Property<int>("ArticulosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticulosId"));

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("ArticulosId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticulosId = 1,
                            Costo = 150.0,
                            Descripcion = "RJ45",
                            Existencia = 200,
                            Precio = 200.0
                        },
                        new
                        {
                            ArticulosId = 2,
                            Costo = 50.0,
                            Descripcion = "MiniJack",
                            Existencia = 100,
                            Precio = 65.0
                        },
                        new
                        {
                            ArticulosId = 3,
                            Costo = 250.0,
                            Descripcion = "Cable USB",
                            Existencia = 125,
                            Precio = 300.0
                        });
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.Property<int>("CotizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CotizacionId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CotizacionId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.CotizacionesDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticulosId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CotizacionId")
                        .HasColumnType("int");

                    b.Property<int?>("CotizacionesCotizacionId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticulosId");

                    b.HasIndex("CotizacionId");

                    b.HasIndex("CotizacionesCotizacionId");

                    b.ToTable("CotizacionesDetalle");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Prioridades", b =>
                {
                    b.Property<int>("PrioridadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrioridadId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tiempo")
                        .HasColumnType("int");

                    b.HasKey("PrioridadId");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TecnicoId"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NombresTecnico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SueldoHora")
                        .HasColumnType("real");

                    b.HasKey("TecnicoId");

                    b.HasIndex("Id");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TiposTecnicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Property<int>("TrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrabajoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<int>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("int");

                    b.HasKey("TrabajoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TrabajosDetalles", b =>
                {
                    b.Property<int>("DetallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetallesId"));

                    b.Property<int>("ArticulosId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("TrabajoId")
                        .HasColumnType("int");

                    b.HasKey("DetallesId");

                    b.HasIndex("ArticulosId");

                    b.HasIndex("TrabajoId");

                    b.ToTable("TrabajosDetalles");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.CotizacionesDetalle", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticulosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Cotizaciones", "Cotizacion")
                        .WithMany("CotizacionesDetalle")
                        .HasForeignKey("CotizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Cotizaciones", "Cotizaciones")
                        .WithMany()
                        .HasForeignKey("CotizacionesCotizacionId");

                    b.Navigation("Articulos");

                    b.Navigation("Cotizacion");

                    b.Navigation("Cotizaciones");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.TiposTecnicos", "TiposTecnicos")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Prioridades", "Prioridades")
                        .WithMany()
                        .HasForeignKey("PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Tecnicos", "Tecnicos")
                        .WithMany()
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Prioridades");

                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TrabajosDetalles", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticulosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Trabajos", "Trabajos")
                        .WithMany("TrabajosDetalles")
                        .HasForeignKey("TrabajoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulos");

                    b.Navigation("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.Navigation("CotizacionesDetalle");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Navigation("TrabajosDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}