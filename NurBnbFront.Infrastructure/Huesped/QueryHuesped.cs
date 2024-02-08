using NurBnbFront.Infrastructure.Huesped.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NurBnbFront.Infrastructure.Conexion;
using System.Threading.Tasks;

namespace NurBnbFront.Infrastructure.Huesped
{
    public class QueryHuesped
    {
       
        public string accessToken { get; set; } 

        public Conexion.Token token { get; set; }

        public async Task<ICollection<HuespedDto>> ObtenerHuesped(string nombres = "")
        {
            
            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var huespedes = await _gateway.ObtenerHuesped(nombres);


            return huespedes;
        }
    }
}
