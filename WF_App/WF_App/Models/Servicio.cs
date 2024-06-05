using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public int? IdVehiculo { get; set; }

    public int? IdCliente { get; set; }

    public int? IdDocs { get; set; }

    public string GasRecibido { get; set; } = null!;

    public DateOnly FechaIn { get; set; }

    public double? KmIn { get; set; }

    public double? MilIn { get; set; }

    public DateOnly FechaOut { get; set; }

    public double? KmOut { get; set; }

    public double? MilOut { get; set; }

    public byte[] Pintura { get; set; } = null!;

    public string Receptor { get; set; } = null!;

    public int? IdCon { get; set; }

    public string? Comentarios { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Condicione? IdConNavigation { get; set; }

    public virtual Documento? IdDocsNavigation { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
