using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MonitoreoModels
{
    public class Usuario
    {
        [Display(Name ="Escribe tu usuario")]
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}
