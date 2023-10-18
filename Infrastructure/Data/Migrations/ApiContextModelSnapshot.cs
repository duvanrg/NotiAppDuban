﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Auditoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DescAccion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Auditoria", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BlockChain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("HashGenerado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdAuditoria")
                        .HasColumnType("int");

                    b.Property<int>("IdHiloRespuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdNotificacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAuditoria");

                    b.HasIndex("IdHiloRespuesta");

                    b.HasIndex("IdNotificacion");

                    b.ToTable("BlockChain", (string)null);
                });

            modelBuilder.Entity("Core.Entities.EstadoNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EstadoNotificacion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Formatos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreFormato")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Formatos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.GenericosVsSubmodulos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdGenericos")
                        .HasColumnType("int");

                    b.Property<int>("IdMaestrosSubmodulos")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGenericos");

                    b.HasIndex("IdMaestrosSubmodulos");

                    b.HasIndex("IdRol");

                    b.ToTable("GenericosVsSubmodulos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.HiloRespuestaNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreTipo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("HiloRespuestaNotificacion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.MaestrosVsSubmodulos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdMaestro")
                        .HasColumnType("int");

                    b.Property<int>("IdSubmodulo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaestro");

                    b.HasIndex("IdSubmodulo");

                    b.ToTable("MaestrosVsSubmodulos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ModuloMaestros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreModulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ModulosMaestros", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ModuloNotificaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AsuntoNotificacion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdEstadoNotificacion")
                        .HasColumnType("int");

                    b.Property<int>("IdFormato")
                        .HasColumnType("int");

                    b.Property<int>("IdHiloNotificacion")
                        .HasColumnType("int");

                    b.Property<int>("IdRadicado")
                        .HasColumnType("int");

                    b.Property<int>("IdRequerimiento")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoNotificacion")
                        .HasColumnType("int");

                    b.Property<string>("TextoNotificacion")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstadoNotificacion");

                    b.HasIndex("IdFormato");

                    b.HasIndex("IdHiloNotificacion");

                    b.HasIndex("IdRadicado");

                    b.HasIndex("IdRequerimiento");

                    b.HasIndex("IdTipoNotificacion");

                    b.ToTable("ModuloNotificaciones", (string)null);
                });

            modelBuilder.Entity("Core.Entities.PermisosGenericos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombrePermiso")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PermisosGenericos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Radicados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Radicados", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Core.Entities.RolVsMaestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdMaestro")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaestro");

                    b.HasIndex("IdRol");

                    b.ToTable("RolVsMaestro", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Submodulos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreSubmodulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Submodulos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreTipo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("TipoNotificacion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoRequerimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("TipoRequerimiento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BlockChain", b =>
                {
                    b.HasOne("Core.Entities.Auditoria", "Auditoria")
                        .WithMany("BlockChains")
                        .HasForeignKey("IdAuditoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.HiloRespuestaNotificacion", "HiloRespuestaNotificacion")
                        .WithMany("BlockChains")
                        .HasForeignKey("IdHiloRespuesta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoNotificacion", "TipoNotificacion")
                        .WithMany("BlockChains")
                        .HasForeignKey("IdNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditoria");

                    b.Navigation("HiloRespuestaNotificacion");

                    b.Navigation("TipoNotificacion");
                });

            modelBuilder.Entity("Core.Entities.GenericosVsSubmodulos", b =>
                {
                    b.HasOne("Core.Entities.PermisosGenericos", "PermisosGenericos")
                        .WithMany("genericosVsSubmodulos")
                        .HasForeignKey("IdGenericos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.MaestrosVsSubmodulos", "MaestrosVsSubmodulos")
                        .WithMany("GenericosVsSubmodulos")
                        .HasForeignKey("IdMaestrosSubmodulos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Rol", "rol")
                        .WithMany("genericosVsSubmodulos")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaestrosVsSubmodulos");

                    b.Navigation("PermisosGenericos");

                    b.Navigation("rol");
                });

            modelBuilder.Entity("Core.Entities.MaestrosVsSubmodulos", b =>
                {
                    b.HasOne("Core.Entities.ModuloMaestros", "ModulosMaestros")
                        .WithMany("MaestrosVsSubmodulos")
                        .HasForeignKey("IdMaestro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Submodulos", "Submodulos")
                        .WithMany("MaestrosVsSubmodulos")
                        .HasForeignKey("IdSubmodulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModulosMaestros");

                    b.Navigation("Submodulos");
                });

            modelBuilder.Entity("Core.Entities.ModuloNotificaciones", b =>
                {
                    b.HasOne("Core.Entities.EstadoNotificacion", "EstadoNotificacion")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdEstadoNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Formatos", "Formatos")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdFormato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.HiloRespuestaNotificacion", "HiloRespuestaNotificacion")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdHiloNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Radicados", "Radicados")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdRadicado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoRequerimiento", "TipoRequerimiento")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdRequerimiento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoNotificacion", "TipoNotificacion")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdTipoNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoNotificacion");

                    b.Navigation("Formatos");

                    b.Navigation("HiloRespuestaNotificacion");

                    b.Navigation("Radicados");

                    b.Navigation("TipoNotificacion");

                    b.Navigation("TipoRequerimiento");
                });

            modelBuilder.Entity("Core.Entities.RolVsMaestro", b =>
                {
                    b.HasOne("Core.Entities.ModuloMaestros", "ModulosMaestros")
                        .WithMany("rolVsMaestros")
                        .HasForeignKey("IdMaestro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Rol", "Rol")
                        .WithMany("rolVsMaestros")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModulosMaestros");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Core.Entities.Auditoria", b =>
                {
                    b.Navigation("BlockChains");
                });

            modelBuilder.Entity("Core.Entities.EstadoNotificacion", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Formatos", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.HiloRespuestaNotificacion", b =>
                {
                    b.Navigation("BlockChains");

                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.MaestrosVsSubmodulos", b =>
                {
                    b.Navigation("GenericosVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.ModuloMaestros", b =>
                {
                    b.Navigation("MaestrosVsSubmodulos");

                    b.Navigation("rolVsMaestros");
                });

            modelBuilder.Entity("Core.Entities.PermisosGenericos", b =>
                {
                    b.Navigation("genericosVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.Radicados", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Navigation("genericosVsSubmodulos");

                    b.Navigation("rolVsMaestros");
                });

            modelBuilder.Entity("Core.Entities.Submodulos", b =>
                {
                    b.Navigation("MaestrosVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.TipoNotificacion", b =>
                {
                    b.Navigation("BlockChains");

                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.TipoRequerimiento", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
