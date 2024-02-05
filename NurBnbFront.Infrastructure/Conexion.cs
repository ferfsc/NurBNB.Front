using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Policy;
using System.Text;



using System.Threading.Tasks;


namespace NurBnbFront.Infrastructure
{
    public class Conexion
    {
        public string ulrGateway { get; set; }
        public Conexion()
        {
            ulrGateway = ConfigurationManager.AppSettings.Get("ApiGateway");
        }
        public async Task<Token> ObtenerToken(string user, string pass)
        {
            string token;
            Token tok;
            try
            {
                using (var client = new HttpClient())
                {                   
                    var data = new Dictionary<string, string>
                    {
                        { "username", user },
                        { "password", pass }
                    };

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    var response = await  client.PostAsJsonAsync(ulrGateway + "api/security/login", data);
                    response.EnsureSuccessStatusCode();

                    var payload = response.Content.ReadAsStringAsync().Result;


                    tok = JsonConvert.DeserializeObject<Token>(payload);
                    token = tok.jwt;
                }
            }
            catch (ArgumentException ex)
            {
                string error = ex.Message;
                tok = null;
            }

            return tok;
        }

        public class Token
        {
            public string jwt { get; set; }
            public string name { get; set; }
        }
    }
}