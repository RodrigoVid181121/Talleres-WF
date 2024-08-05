using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class ListaServicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
