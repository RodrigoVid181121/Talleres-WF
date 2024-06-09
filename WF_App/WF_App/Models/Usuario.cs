using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string? Contraseña { get; set; }

    public int? IdCargo { get; set; }

    public decimal Salario { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Cargo? IdCargoNavigation { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
