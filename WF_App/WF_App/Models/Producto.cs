using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public short Cantidad { get; set; }

    public decimal PrecioCosto { get; set; }

    public decimal PrecioVenta { get; set; }

    public string? ModeloVehiculo { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();
}
