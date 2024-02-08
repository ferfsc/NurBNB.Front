using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Reserva
{
    public class RegisterReserva
    {
        public Conexion.Token token { get; set; }

        public async Task<string> RegistrarReserva(string huespedID, string propiedadID, DateTime fechaCheckIn, DateTime fechaCheckOut,
                                                 string motivo)
        {

            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var idPropiedad = await _gateway.RegistarReserva(huespedID, propiedadID, fechaCheckIn, fechaCheckOut, motivo);


            return idPropiedad;
        }
    }
}
