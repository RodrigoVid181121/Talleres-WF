using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdProveedor { get; set; }

    public string TipoDoc { get; set; } = null!;

    public int NumeroDoc { get; set; }

    public decimal MontoTot { get; set; }

    public DateTime? FechaCompra { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedore? IdProveedorNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
