using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Reserva.Dto
{
    public class ListOfReservaDto
    {
        public string IDReserva { get; set; }
        public string HuespedID { get; set; }
        public string PropiedadID { get; set; }
        public DateTime FechaCheckin { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public string Detalle { get; set; }
        public string Cliente { get; set; }
    }
}
