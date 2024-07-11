using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Syssaladebelleza.EN;

public partial class Rol
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    
    public string Nombre { get; set; } = null!;

    public ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
