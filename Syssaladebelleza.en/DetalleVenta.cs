using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Syssaladebelleza.EN;

public class DetalleVenta
{
    [Key]
    public int Id { get; set; }

    public int IdVenta { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Precio { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Suma { get; set; }
}
