using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MercyDevelopers.Models;

public partial class MercyDevelopersContext : DbContext
{
    public MercyDevelopersContext()
    {
    }

    public MercyDevelopersContext(DbContextOptions<MercyDevelopersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteHasServicio> ClienteHasServicios { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

    if (!optionsBuilder.IsConfigured)
    {

    }
}
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("ID_Cliente");
            entity.Property(e => e.Apellido).HasMaxLength(45);
            entity.Property(e => e.Correo).HasMaxLength(45);
            entity.Property(e => e.Direccion).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Rut).HasMaxLength(15);
            entity.Property(e => e.Telefono).HasMaxLength(45);
        });

        modelBuilder.Entity<ClienteHasServicio>(entity =>
        {
            entity.HasKey(e => e.IdClienteHasServicios).HasName("PRIMARY");

            entity.ToTable("cliente_has_servicios");

            entity.HasIndex(e => e.IdCliente, "ID_Cliente_idx");

            entity.HasIndex(e => e.IdServicios, "ID_Servicios_idx");

            entity.Property(e => e.IdClienteHasServicios)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("ID_Cliente_Has_Servicios");
            entity.Property(e => e.IdCliente)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Cliente");
            entity.Property(e => e.IdServicios)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Servicios");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClienteHasServicios)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ID_Cliente");

            entity.HasOne(d => d.IdServiciosNavigation).WithMany(p => p.ClienteHasServicios)
                .HasForeignKey(d => d.IdServicios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ID_Servicios");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicios).HasName("PRIMARY");

            entity.ToTable("servicios");

            entity.Property(e => e.IdServicios)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("ID_Servicios");
            entity.Property(e => e.Categoria).HasMaxLength(45);
            entity.Property(e => e.Descripción).HasMaxLength(500);
            entity.Property(e => e.Duraccion).HasColumnType("datetime");
            entity.Property(e => e.Estado).HasMaxLength(45);
            entity.Property(e => e.Precio).HasMaxLength(45);
            entity.Property(e => e.Productos).HasMaxLength(45);
            entity.Property(e => e.TecnicoAsignado)
                .HasMaxLength(45)
                .HasColumnName("Tecnico_Asignado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
