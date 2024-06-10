using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Ga
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
