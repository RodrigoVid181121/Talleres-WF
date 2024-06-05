using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Contabilidad
{
    public int Id { get; set; }

    public string TipoTrans { get; set; } = null!;

    public string Concepto { get; set; } = null!;

    public decimal Monto { get; set; }

    public string TipoPago { get; set; } = null!;

    public decimal Balance { get; set; }
}
