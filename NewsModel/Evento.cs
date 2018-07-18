using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoModels
{
   public class Evento
    {
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string  Description { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string Color { get; set; }
        public bool IsFullDay { get; set; }
    }
}
