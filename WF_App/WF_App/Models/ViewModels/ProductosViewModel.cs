using System.ComponentModel.DataAnnotations;

namespace WF_App.Models.ViewModels
{
    public class ProductosViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public short Cantidad { get; set; }
        [Required]
        public string Medida { get; set; }
        [Required]
        public string Biscosidad { get; set; }
        [Required]
        public decimal PrecioVenta { get; set; }
        [Required]
        public string ModeloVehiculo { get; set; }
        [Required]
        public int? IdMarca { get; set; }
        [Required]
        public int? IdCategoria { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string MarcaNombre { get; set; }
        [Required]
        public string CategoriaNombre { get; set; }
        [Required]
    }
}