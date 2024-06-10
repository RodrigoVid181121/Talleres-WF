using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int? IdUsuario { get; set; }

    public string TipoDoc { get; set; } = null!;

    public int NumeroDoc { get; set; }

    public int? IdCliente { get; set; }

    public decimal MontoTotal { get; set; }

    public decimal? MontoCambio { get; set; }

    public int? Descuento { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
