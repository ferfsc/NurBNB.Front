﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static NurBnbFront.Infrastructure.Conexion;
using NurBnbFront.Infrastructure.Huesped.Dto;
using System.Collections.ObjectModel;
using System.Security.Policy;

namespace NurBnbFront.Infrastructure
{
    public class CallGateway
    {
        private string ulrGateway { get; set; }

        public Conexion.Token token { get; set; }

        public string accessToken { get; set; } 

        public CallGateway()
        {
            ulrGateway = ConfigurationManager.AppSettings.Get("ApiGateway");
        }
        public async Task<ICollection<HuespedDto>> ObtenerHuesped(string nombres = "")
        {
            ICollection<HuespedDto> huespedes;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                   
                    
                    //client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (token != null && token.jwt.Length > 0)
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.jwt);

                    string url = ulrGateway + "api/Huesped/BuscarHuesped?searchTerm=" + nombres + "";
                    var response = await client.GetStringAsync(ulrGateway + "api/Huesped/BuscarHuesped?searchTerm="+ nombres +"");
                    
                    var _huespedes = JsonConvert.DeserializeObject<List<HuespedDto>>(response);

                    return _huespedes;
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    huespedes =  await response.Content.ReadAsAsync<ICollection<HuespedDto>>();
                    //    return huespedes;
                    //}


                }
            }
            catch (ArgumentException ex)
            {
                string error = ex.Message;               
            }

            return null;
        }

        public async Task<string> RegistarHuesped(string nombre, string apellidos, string telefono, string nroDoc,
                                                 string email, string calle, string ciudad, string pais, string codPostal)
        {
            string result;
            try
            {
                using (var client = new HttpClient())
                {
                    var data = new Dictionary<string, string>
                    {
                        { "nombre", nombre },
                        { "apellidos", apellidos },
                        { "telefono", telefono },
                        { "nroDoc", nroDoc },
                        { "email", email },
                        { "calle", calle },
                        { "ciudad", ciudad },
                        { "pais", pais },
                        { "codigoPostal", codPostal }

                    };

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    //if (token != null && token.jwt.Length > 0)
                    //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.jwt);

                    var response = await client.PostAsJsonAsync(ulrGateway + "api/NurBNB/CrearHuesped", data);

                    if (response.IsSuccessStatusCode)
                    {
                        result = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<string>(result);
                    }
                    else
                        result = "";
                    
                    //tok = JsonConvert.DeserializeObject<Token>(payload);
                    //token = tok.jwt;
                }
            }
            catch (ArgumentException ex)
            {
                string error = ex.Message;
                result = string.Empty;
            }

            return result;
        }
    }
}
