using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Syssaladebelleza.EN;

namespace Syssaladebelleza.EN;

public partial class Venta
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("IdUsuario")]
    public int IdUsuario { get; set; }

    //decimal
    public decimal? VentasExentas { get; set; }

    public decimal Descuento { get; set; }

    [Column("IVA", TypeName = "decimal(18, 0)")]
    public decimal? Iva { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal TotalPagar { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Codigo { get; set; }

    [StringLength(50)]

    public string? Nombre { get; set; }

    [StringLength(50)]

    public string? Dirrecion { get; set; }
    [NotMapped]
    public int Top_Aux { get; set; }

    public List<DetalleVenta>? DetalleVenta { get; set; }



    public Usuario Usuario { get; set; } = null!;
}