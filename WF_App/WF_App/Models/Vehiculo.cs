using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string Placa { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Color { get; set; } = null!;

    public byte Año { get; set; }

    public string Tipo { get; set; } = null!;

    public int? IdGas { get; set; }

    public int? IdCliente { get; set; }

    public int? IdDocs { get; set; }

    public string? Receptor { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Documento? IdDocsNavigation { get; set; }

    public virtual Ga? IdGasNavigation { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
