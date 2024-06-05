using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class DetalleCompra
{
    public int IdDetalleCompra { get; set; }

    public int? IdCompra { get; set; }

    public int? IdProducto { get; set; }

    public decimal PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public decimal Total { get; set; }

    public string MetodoPago { get; set; } = null!;

    public DateTime? FechaCompra { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
