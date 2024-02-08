using NurBnbFront.Infrastructure.Pago.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Pago
{
    public class QueryCatalogoDevolucion
    {
        public string accessToken { get; set; }

        public Conexion.Token token { get; set; }

        public async Task<List<CatalogoDevolucionDto>> ObtenerCatalogoDevolucion(string search = "")
        {

            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var catalogos = await _gateway.ObtenerCatalogoDevolucion(search);


            return catalogos;
        }
    }
}
