using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Propiedad
{
    public class RegisterPropiedad
    {
        public Conexion.Token token { get; set; }

        public async Task<string> RegistrarPropiedad(string propietarioID, string titulo, decimal precio, string detalle,
                                                 string ubicacion, string estado)
        {

            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var idPropiedad = await _gateway.RegistarPropiedad(propietarioID, titulo, precio, detalle, ubicacion, estado);


            return idPropiedad;
        }
    }
}
