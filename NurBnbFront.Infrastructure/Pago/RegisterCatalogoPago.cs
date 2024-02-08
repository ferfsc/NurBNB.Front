using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Pago
{
    public class RegisterCatalogoPago
    {
        public Conexion.Token token { get; set; }

        public async Task<string> RegistrarCatalogoPago(string descripcion, int porcentaje, int tipo)
        {

            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var idPropiedad = await _gateway.RegistarCatalogoPago(descripcion, porcentaje, tipo);


            return idPropiedad;
        }
    }
}
