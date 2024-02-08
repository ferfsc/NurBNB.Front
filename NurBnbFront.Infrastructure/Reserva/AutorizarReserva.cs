using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Reserva
{
    public class AutorizarReserva
    {
        public Conexion.Token Token { get; set; }

        public async Task<string> ConfirmarReserva(string reservaID)
        {

            CallGateway _gateway = new CallGateway
            {
                token = Token
            };

            var idPropiedad = await _gateway.ConfirmarReserva(reservaID);


            return idPropiedad;
        }

        public async Task<string> RechazarReserva(string reservaID)
        {

            CallGateway _gateway = new CallGateway
            {
                token = Token
            };

            var idPropiedad = await _gateway.RechazarReserva(reservaID);


            return idPropiedad;
        }
    }
}
