﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using projectef;

#nullable disable

namespace projectef.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20230805080957_AddDefaultValueToCreatedAtOnTaskTable")]
    partial class AddDefaultValueToCreatedAtOnTaskTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("projectef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded125d7"),
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded12502"),
                            Nombre = "Actividades personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("projectef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2023, 8, 5, 10, 9, 57, 624, DateTimeKind.Local).AddTicks(6720));

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("categoriaId")
                        .HasColumnType("uuid");

                    b.HasKey("TareaId");

                    b.HasIndex("categoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded12510"),
                            FechaCreacion = new DateTime(2023, 8, 5, 8, 9, 57, 624, DateTimeKind.Utc).AddTicks(6030),
                            PrioridadTarea = 1,
                            Titulo = "Pago de servicios publicos",
                            categoriaId = new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded125d7")
                        },
                        new
                        {
                            TareaId = new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded12511"),
                            FechaCreacion = new DateTime(2023, 8, 5, 8, 9, 57, 624, DateTimeKind.Utc).AddTicks(6030),
                            PrioridadTarea = 0,
                            Titulo = "Terminar de ver pelicula en Netflix",
                            categoriaId = new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded12502")
                        });
                });

            modelBuilder.Entity("projectef.Models.Tarea", b =>
                {
                    b.HasOne("projectef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("projectef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
