using System;
using System.Collections.Generic;

namespace WF_App.Models;

public partial class Condicione
{
    public int Id { get; set; }

    public bool Radio { get; set; }

    public bool MascaraRadio { get; set; }

    public bool PerillaCal { get; set; }

    public bool AireAc { get; set; }

    public bool ContAlar { get; set; }

    public bool Pito { get; set; }

    public bool EspInt { get; set; }

    public bool EspExt { get; set; }

    public bool Antena { get; set; }

    public bool TapaLlanta { get; set; }

    public bool EmblemaLat { get; set; }

    public bool EmblemaPost { get; set; }

    public bool Gato { get; set; }

    public bool LlaveRueda { get; set; }

    public bool Herramientas { get; set; }

    public bool KitCarretera { get; set; }

    public bool TapaGas { get; set; }

    public bool Encendedor { get; set; }

    public bool TapaLiqFrenos { get; set; }

    public bool TapaFusibles { get; set; }

    public bool Alfombras { get; set; }

    public bool LlantaEmergencia { get; set; }

    public bool CopaLlantas { get; set; }

    public bool CableCorriente { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
