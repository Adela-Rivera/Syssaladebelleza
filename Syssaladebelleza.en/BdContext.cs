using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Syssaladebelleza.EN;

public partial class BbContext : DbContext
{
    public BbContext()
    {
    }

    public BbContext(DbContextOptions<BbContext> options)
        : base(options)
    {
    }

    public DbSet<DetalleVenta> DetalleVenta { get; set; }

    public  DbSet<Producto> Producto { get; set; }

    public DbSet<Rol> Rol { get; set; }

    public  DbSet<Usuario> Usuario { get; set; }

    public  DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=BDsaladebelleza2022.mssql.somee.com;packet size=4096;user id=Rivera_SQLLogin_1;pwd=97lg78wsl5;data source=BDsaladebelleza2022.mssql.somee.com;persist security info=False;initial catalog=BDsaladebelleza2022;Encrypt=False;TrustServerCertificate=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC07AF5237E4");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07CC516FA5");

            entity.Property(e => e.Password).IsFixedLength();

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
