using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public short Cantidad { get; set; }

    public decimal PrecioVenta { get; set; }

    public string? ModeloVehiculo { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdMarca { get; set; }

    public string? Medida { get; set; }

    public string? Biscosidad { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }
}
