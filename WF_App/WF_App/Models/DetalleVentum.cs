using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class DetalleVentum
{
    public int IdDetalle { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public decimal PrecioVenta { get; set; }

    public string TipoPago { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal Subtotal { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Ventum? IdVentaNavigation { get; set; }
}
