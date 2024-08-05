using System.ComponentModel.DataAnnotations;

namespace WF_App.Models.ViewModels
{
    public class FacturacionViewModel
    {
        //Crear venta
        public string Placa { get; set; }
        public string? TipoDoc { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoTotal { get; set; }

        //creacion del detalle de venta
        public string Productos { get; set; }
        public int? IdProductos { get; set; }
        public string FormaPago { get; set; }
        public int? Cantidad { get; set; }
    }
}
