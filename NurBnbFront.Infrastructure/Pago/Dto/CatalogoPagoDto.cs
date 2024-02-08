using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Pago.Dto
{
    public class CatalogoPagoDto
    {
        public string CatalogoId { get; set; }
        public string Descripcion { get; set; }
        public int Porcentaje { get; set; }
        public string Tipo { get; set; }
    }
}
