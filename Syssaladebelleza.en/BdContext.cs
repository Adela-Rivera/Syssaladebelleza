using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Syssaladebelleza.EN;

namespace Syssaladebelleza.EN;

public partial class BdContext : DbContext
{
    public BdContext()
    {
    }

    public BdContext(DbContextOptions<BdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("workstation id=BDsaladebelleza2022.mssql.somee.com;packet size=4096;user id=Rivera_SQLLogin_1;pwd=97lg78wsl5;data source=BDsaladebelleza2022.mssql.somee.com;persist security info=False;initial catalog=BDsaladebelleza2022;TrustServerCertificate=True");
    }


}


