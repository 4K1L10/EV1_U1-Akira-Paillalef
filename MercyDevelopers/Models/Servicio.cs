using System;
using System.Collections.Generic;

namespace MercyDevelopers.Models;

public partial class Servicio
{
    public int IdServicios { get; set; }

    public string? Productos { get; set; }

    public string? Precio { get; set; }

    public DateTime? Duraccion { get; set; }

    public string? Estado { get; set; }

    public string? TecnicoAsignado { get; set; }

    public string? Categoria { get; set; }

    public string? Descripción { get; set; }

    public virtual ICollection<ClienteHasServicio> ClienteHasServicios { get; set; } = new List<ClienteHasServicio>();
}
