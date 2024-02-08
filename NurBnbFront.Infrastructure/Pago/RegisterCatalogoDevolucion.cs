using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Pago
{
    public class RegisterCatalogoDevolucion
    {
        public Conexion.Token token { get; set; }

        public async Task<string> RegistrarCatalogoDevolucion(string descripcion, int porcentaje, int nrodias)
        {

            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var idPropiedad = await _gateway.RegistarCatalogoDevolucion(descripcion, porcentaje, nrodias);


            return idPropiedad;
        }
    }
}
