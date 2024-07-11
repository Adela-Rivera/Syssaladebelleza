using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Syssaladebelleza.EN;

public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("IdRol")]

    public int IdRol { get; set; }

    [StringLength(30)]
   
    public string Nombre { get; set; } = null!;

    [StringLength(30)]
   
    public string Apellido { get; set; } = null!;

    [StringLength(25)]
   
    public string Login { get; set; } = null!;

    [StringLength(32)]
   
    public string Password { get; set; } = null!;

    public byte Estatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaRegistro { get; set; }

    
    public  Rol Rol { get; set; } = null!;
}
