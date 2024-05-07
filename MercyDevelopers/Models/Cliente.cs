using System;
using System.Collections.Generic;

namespace MercyDevelopers.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Rut { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<ClienteHasServicio> ClienteHasServicios { get; set; } = new List<ClienteHasServicio>();
}
