using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsModel;
namespace NewsMockDataAccess
{
    public class MockDA
    {

        public static IEnumerable<Nota> GetNota()
        {
            List<Nota> places = new List<Nota>();
            places.Add(new Nota()
            {
                Notaid = 1,
                Titulo = "Nota de prueba",
                Reportero = "Luis Daniel Sotelo",
                Seccion = "Principal",
                Categoria = "Academica",
                Fecha = new DateTime(2018, 4, 10),
                Ubicacion = "Portada",
                Relevancia = "Muy importante",
                Espacio = "cuadro amplio",
                Archivo = "directorio",
                Dimensiones = "25x30",
                Precio = new decimal(100.50),
                Privacidad = 'N',
                DiarioImpreso = "El Siglo de Torreon"
            });

            return places;
        }
    }
}
