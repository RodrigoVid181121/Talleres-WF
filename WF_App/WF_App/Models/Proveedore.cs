using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string NombreProveedor { get; set; } = null!;

    public string CodigoProveedor { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
