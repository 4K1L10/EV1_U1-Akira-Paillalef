using System;
using System.Collections.Generic;

namespace MercyDevelopers.Models;

public partial class ClienteHasServicio
{
    public int IdClienteHasServicios { get; set; }

    public int IdCliente { get; set; }

    public int IdServicios { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Servicio IdServiciosNavigation { get; set; } = null!;
}
