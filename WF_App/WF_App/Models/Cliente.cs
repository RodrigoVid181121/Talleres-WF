using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
