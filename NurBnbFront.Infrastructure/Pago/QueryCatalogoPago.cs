using NurBnbFront.Infrastructure.Pago.Dto;
using NurBnbFront.Infrastructure.Reserva.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Pago
{
    public class QueryCatalogoPago
    {
        public string accessToken { get; set; }

        public Conexion.Token token { get; set; }

        public async Task<List<CatalogoPagoDto>> ObtenerCatalogoPago(string search = "")
        {

            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var catalogos = await _gateway.ObtenerCatalogoPago(search);


            return catalogos;
        }
    }
}
