﻿// <auto-generated />
using System;
using GeJu.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeJu.Sql.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210117010853_UpdateProduct")]
    partial class UpdateProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeJu.Sql.Entities.Marca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("FechaCreado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<DateTime>("FechaModificado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("GeJu.Sql.Entities.Producto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CodigoBarra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CostoPromedio")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Existencia")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<Guid?>("MarcaId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("TamanhoId")
                        .HasColumnType("int");

                    b.Property<bool>("Vencimiento")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId1");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("GeJu.Sql.Entities.ProductoTamaño", b =>
                {
                    b.Property<Guid>("ProductoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TamañoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("ProductoId", "TamañoId");

                    b.HasIndex("TamañoId");

                    b.ToTable("ProductoTamaños");
                });

            modelBuilder.Entity("GeJu.Sql.Entities.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificado")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GeJu.Sql.Entities.Tamaño", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<DateTime>("FechaModificado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetUtcDate()");

                    b.HasKey("Id");

                    b.ToTable("Tamaños");
                });

            modelBuilder.Entity("GeJu.Sql.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deuda")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<DateTime>("FechaModificado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<DateTime>("FechaNaciento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pais")
                        .HasColumnType("int");

                    b.Property<DateTime>("UltimoInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GeJu.Sql.Entities.UsuarioRol", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UsuarioId", "RolId");

                    b.HasIndex("RolId");

                    b.ToTable("UsuariosRoles");
                });

            modelBuilder.Entity("GeJu.Sql.Entities.Producto", b =>
                {
                    b.HasOne("GeJu.Sql.Entities.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId1");
                });

            modelBuilder.Entity("GeJu.Sql.Entities.ProductoTamaño", b =>
                {
                    b.HasOne("GeJu.Sql.Entities.Producto", "Producto")
                        .WithMany("ProductoTamaños")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeJu.Sql.Entities.Tamaño", "Tamaño")
                        .WithMany("ProductoTamaños")
                        .HasForeignKey("TamañoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeJu.Sql.Entities.UsuarioRol", b =>
                {
                    b.HasOne("GeJu.Sql.Entities.Rol", "Rol")
                        .WithMany("UsuariosRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeJu.Sql.Entities.Usuario", "Usuario")
                        .WithMany("UsuariosRoles")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
