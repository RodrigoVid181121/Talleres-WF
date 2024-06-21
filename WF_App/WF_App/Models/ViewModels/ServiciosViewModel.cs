using System.ComponentModel.DataAnnotations;

namespace WF_App.Models.ViewModels
{
    public class ServiciosViewModel
    {
        public List<Ga> Gas { get; set; }
        //Datos de quien entrega
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Celular { get; set; }
        public string Cargo { get; set; }
        [Required]
        public string Encargado { get; set; }

        //Vehiculo
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public int Año { get; set; }
        [Required]
        [Display(Name ="Tipo Gas")]
        public int Combustible { get; set; }

        //Documentos
        [Required]
        public int Llaves { get; set; }
        [Required]
        public int Tarjeta { get; set; }
        [Required]
        public int Poliza { get; set; }
        [Required]
        public int Control_Alarma { get; set; }

        //Servicio
        [Required]
        [Display(Name ="Recibe")]
        public string Receptor { get; set; }
        [Required]
        [Display(Name ="Combustible")]
        public string CantGas { get; set; }
        [Required]
        public string Mecanico { get; set; }
        [Required]
        [Display(Name ="Fecha de ingreso")]
        public string FechaIn { get; set; }
        public string FechaOut { get; set; }
        [Required]
        public string Distancia { get; set; }
        [Required]
        public string KilIn { get; set; }
        [Required]
        public string KilOut { get; set; }

        //Condiciones de entrega

        [Required]
        public int Radio { get; set; }
        [Required]
        public int MascRad { get; set; }
        [Required]
        public int PerillaCal { get; set; }
        [Required]
        public int AC { get; set; }
        [Required]
        public int ControlAlarma { get; set; }
        [Required]
        public int Pito { get; set; }
        [Required]
        public int EspejoIn { get; set; }
        [Required]
        public int Antena { get; set; }
        [Required]
        public int TapaLlanta { get; set; }
        [Required]
        public int EspejoExt { get; set; }
        [Required]
        public int EmbLat { get; set; }
        [Required]
        public int EmbPost { get; set; }
        [Required]
        public int Gato { get; set; }
        [Required]
        public int LlaveRuedas { get; set; }
        [Required]
        public int Herramientas { get; set; }
        [Required]
        public int KitCarretera { get; set; }
        [Required]
        public int TapaGas { get; set; }
        [Required]
        public int Encendedor { get; set; }
        [Required]
        public int TapaLiqFrenos { get; set; }
        [Required]
        public int TapaFusibles { get; set; }
        [Required]
        public int Alfombras { get; set; }
        [Required]
        public int LlantaEmergencia { get; set; }
        [Required]
        public int CopaLlanta { get; set; }
        [Required]
        public int CableCorriente { get; set; }
    }
}
