using System.ComponentModel.DataAnnotations;

namespace WF_App.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(6)]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }  
        public string? ErrorMessage { get; set; }
    }
}
