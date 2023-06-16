<<<<<<<< HEAD:SalasDeEnsayo/Infraestructura/Migrations/20230616135637_StartUp.Designer.cs
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalasDeEnsayo.Infraestructura;

#nullable disable

namespace SalasDeEnsayo.Infraestructura.Migraciones
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230616135637_StartUp")]
    partial class StartUp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SalasDeEnsayo.Entidades.listadeprecio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("dia")
                        .HasColumnType("int");

                    b.Property<double>("precioxhora")
                        .HasColumnType("float");

                    b.Property<int>("tiposalaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tiposalaid");

                    b.ToTable("listadeprecio");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.saladeensayo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("capacidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar")
                        .HasColumnName("descripcion_sala");

                    b.Property<bool>("habilitado")
                        .HasColumnType("bit");

                    b.Property<int>("tipodesalaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tipodesalaid");

                    b.ToTable("saladeensayo");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.tipodesala", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<bool>("habilitado")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("tipodesala");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.listadeprecio", b =>
                {
                    b.HasOne("SalasDeEnsayo.Entidades.tipodesala", "tiposala")
                        .WithMany("listadeprecios")
                        .HasForeignKey("tiposalaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tiposala");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.saladeensayo", b =>
                {
                    b.HasOne("SalasDeEnsayo.Entidades.tipodesala", "tipo")
                        .WithMany("saladeensayos")
                        .HasForeignKey("tipodesalaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tipo");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.tipodesala", b =>
                {
                    b.Navigation("listadeprecios");

                    b.Navigation("saladeensayos");
                });
#pragma warning restore 612, 618
        }
    }
}
========
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalasDeEnsayo.Infraestructura;

#nullable disable

namespace SalasDeEnsayo.Infraestructura.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230616144105_20230616")]
    partial class _20230616
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SalasDeEnsayo.Entidades.instrumento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<DateTime>("fechacompra")
                        .HasColumnType("datetime2");

                    b.Property<bool>("habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.HasKey("id");

                    b.ToTable("instrumento");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.listadeprecio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("dia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<long>("precioxhora")
                        .HasColumnType("bigint");

                    b.Property<int>("tiposalaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tiposalaid");

                    b.ToTable("listadeprecio");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.reserva", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("fechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("salaDeEnsayoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("salaDeEnsayoId");

                    b.ToTable("reserva");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.saladeensayo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("capacidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar")
                        .HasColumnName("descripcion_sala");

                    b.Property<bool>("habilitado")
                        .HasColumnType("bit");

                    b.Property<int>("reservaid")
                        .HasColumnType("int");

                    b.Property<int>("tipodesalaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tipodesalaid");

                    b.ToTable("saladeensayo");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.saladeensayoequipamiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("instrumentoid")
                        .HasColumnType("int");

                    b.Property<int>("salasdeensayoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("instrumentoid");

                    b.HasIndex("salasdeensayoid");

                    b.ToTable("saladeensayoequipamiento");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.tipodesala", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<bool>("habilitado")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("tipodesala");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.listadeprecio", b =>
                {
                    b.HasOne("SalasDeEnsayo.Entidades.tipodesala", "tiposala")
                        .WithMany("listadeprecios")
                        .HasForeignKey("tiposalaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tiposala");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.reserva", b =>
                {
                    b.HasOne("SalasDeEnsayo.Entidades.saladeensayo", "salaDeEnsayo")
                        .WithMany("reservas")
                        .HasForeignKey("salaDeEnsayoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("salaDeEnsayo");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.saladeensayo", b =>
                {
                    b.HasOne("SalasDeEnsayo.Entidades.tipodesala", "tipo")
                        .WithMany("saladeensayos")
                        .HasForeignKey("tipodesalaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tipo");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.saladeensayoequipamiento", b =>
                {
                    b.HasOne("SalasDeEnsayo.Entidades.instrumento", "instrumento")
                        .WithMany("Equipamiento")
                        .HasForeignKey("instrumentoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalasDeEnsayo.Entidades.saladeensayo", "salasdeensayo")
                        .WithMany("equipamiento")
                        .HasForeignKey("salasdeensayoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("instrumento");

                    b.Navigation("salasdeensayo");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.instrumento", b =>
                {
                    b.Navigation("Equipamiento");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.saladeensayo", b =>
                {
                    b.Navigation("equipamiento");

                    b.Navigation("reservas");
                });

            modelBuilder.Entity("SalasDeEnsayo.Entidades.tipodesala", b =>
                {
                    b.Navigation("listadeprecios");

                    b.Navigation("saladeensayos");
                });
#pragma warning restore 612, 618
        }
    }
}
>>>>>>>> main:SalasDeEnsayo/Infraestructura/Migrations/20230616144105_20230616.Designer.cs
