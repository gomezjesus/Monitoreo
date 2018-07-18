using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NewsModel
{
    public class Nota
    {
        public int Notaid { get; set; }
        [Required(ErrorMessage = "Escribe un nombre para Título")]
        public string  Titulo { get; set; }   
        [Required(ErrorMessage ="Escribe un nombre para reportero")]
        public string  Reportero { get; set; }
        public string Seccion { get; set; }  
        [Required(ErrorMessage ="Selecciona una categoria")]
        public int SeccionID { get; set; }
        [Required(ErrorMessage = "Selecciona un género")]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage = "Selecciona un diario")]
        public int DiarioImpresoID { get; set; }        
        public string Categoria  { get; set; }        
        [DataType(DataType.Date),Required(ErrorMessage ="Selecciona una fecha")]        
        public DateTime Fecha { get; set; }        
        public string  Ubicacion { get; set; }  
        [Range(1,3,ErrorMessage ="Rango entre 1-3")]
        public int Relevancia { get; set; }           
        public string Archivo { get; set; }        
        [Required(ErrorMessage = "Selecciona dimensiones en el formato: anchoxlargo")]
        public string Dimensiones { get; set; }
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Introduce un numero con 2 decimales.")]
        public string Precio { get; set; }        
        public char Privacidad { get; set; }    
        [DisplayName("Medio")]
        public string DiarioImpreso { get; set; }        
        public SelectList Categorias { get; set; }
        public SelectList Secciones { get; set; }
        public SelectList Diarios { get; set; }
        [Required(ErrorMessage = "Escriba los tags separados por coma")]
        public string Tag { get; set; }
    }
}
