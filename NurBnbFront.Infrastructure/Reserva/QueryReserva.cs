using NurBnbFront.Infrastructure.Huesped.Dto;
using NurBnbFront.Infrastructure.Propiedad.Dto;
using NurBnbFront.Infrastructure.Reserva.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Reserva
{
    public class QueryReserva
    {
        public string accessToken { get; set; }

        public Conexion.Token token { get; set; }

        public async Task<List<ListOfReservaDto>> ObtenerReservas( string nombres = "")
        {

            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var reservas = await _gateway.ObtenerReservas(nombres);


            return reservas;
        }
    }
}
