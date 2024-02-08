using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Propiedad.Dto
{
    public class ListofPropiedadesDto
    {
        public Guid IDPropiedad { get; set; }
        public string PropietarioID { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public string Detalle { get; set; }
        public string Ubicacion { get; set; }
        public string Estado { get; set; }
        public string Propietario { get; set; }
    }
}
