using System.ComponentModel.DataAnnotations;

namespace WF_App.Models.ViewModels
{
    public class ServiciosViewModel
    {
        public string? key { get; set; }
        public string? PlacaSearch { get; set; }
        public string? Action {  get; set; }
        //Datos de quien entrega
        [Required]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(9)]
        [MinLength(8)]
        public string Celular { get; set; }
        [MaxLength(50)]
        public string? Cargo { get; set; }
        [MaxLength(75)]
        public string? Encargado { get; set; }

        //Vehiculo
        [Required]
        [MaxLength(6)]
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
        [MaxLength(75)]
        public string Mecanico { get; set; }
        [Required]
        public string Distancia { get; set; }
        [Required]
        [Display(Name ="Kilometraje de ingreso")]
        public int KilIn { get; set; }
        [Display(Name = "Kilometraje de salida")]
        public int? KilOut { get; set; }
        [MaxLength(500)]
        public string? Comentarios { get; set; }
        public string? Imagen { get; set; }
        [Display(Name ="Servicio")]
        [Required]
        public int? IdServicio { get; set; }

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
