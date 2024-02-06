using NurBnbFront.Infrastructure.Huesped.Dto;
using NurBnbFront.Infrastructure.Propiedad.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Propiedad
{
    public class QueryPropiedades
    {
        public string accessToken { get; set; }

        public Conexion.Token token { get; set; }

        public async Task<List<ListofPropiedadesDto>> ObtenerPropiedades(string nombres = "")
        {

            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var propiedades = await _gateway.ObtenerPropiedades(nombres);


            return propiedades;
        }
    }
}
