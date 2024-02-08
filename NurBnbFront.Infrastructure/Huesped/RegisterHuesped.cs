using Newtonsoft.Json;
using NurBnbFront.Infrastructure.Huesped.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static NurBnbFront.Infrastructure.Conexion;

namespace NurBnbFront.Infrastructure.Huesped
{
    public class RegisterHuesped
    {
        public Conexion.Token token { get; set; }

        public async Task<string> RegistrarHuesped(string nombre, string apellidos, string telefono, string nroDoc,
                                                 string email, string calle, string ciudad, string pais, string codPostal)
        {

            CallGateway _gateway = new CallGateway();

            _gateway.token = token;

            var idHuesped = await _gateway.RegistarHuesped(nombre,apellidos, telefono, nroDoc, email, calle, ciudad, pais, codPostal);


            return idHuesped;
        }
    }
}
