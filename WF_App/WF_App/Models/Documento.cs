using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Documento
{
    public int Id { get; set; }

    public bool Llave { get; set; }

    public bool Tarjeta { get; set; }

    public bool Poliza { get; set; }

    public bool Alarma { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
