using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public int? IdVehiculo { get; set; }

    public string GasRecibido { get; set; } = null!;

    public bool Estado { get; set; }

    public string? FechaIn { get; set; }

    public int? KmIn { get; set; }

    public int? MilIn { get; set; }

    public string? FechaOut { get; set; }

    public int? KmOut { get; set; }

    public int? MilOut { get; set; }

    public string? Pintura { get; set; }

    public string Receptor { get; set; } = null!;

    public string Mecanico { get; set; } = null!;

    public string? EncargadoVehi { get; set; }

    public string? CargoEn { get; set; }

    public string? Comentarios { get; set; }

    public int? IdServicio { get; set; }

    public bool? Anulado { get; set; }

    public virtual ListaServicio? IdServicioNavigation { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
