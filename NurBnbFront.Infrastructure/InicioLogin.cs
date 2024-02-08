//using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace NurBnbFront.Infrastructure
{
    public class InicioLogin
    {
        //private readonly IMemoryCache _memory;
        public Conexion.Token token { get; set; }
        
        public string Nombre { get; set; }

        public async Task<Conexion.Token> InicioSession(string user, string pass)
        {
            Conexion cnx = new Conexion();
            
            token = await cnx.ObtenerToken(user, pass);

            Nombre = token.name;

            return token;
        }

    }
}
