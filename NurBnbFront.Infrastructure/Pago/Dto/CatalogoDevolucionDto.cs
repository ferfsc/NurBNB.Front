using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Pago.Dto
{
    public class CatalogoDevolucionDto
    {
        public string CatalogoDevolucionId { get; set; }
        public string Descripcion { get; set; }
        public int NroDias { get; set; }
        public int PorcentajeDescuento { get; set; }
    }
}
