using _16_CRUDpersonas_API_DAL.connection;
using _16_CRUDpersonas_API_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace _16_CRUDpersonas_API_DAL.lists {
    public class clsListadoPersonas_DAL {

        public async Task<List<clsPersona>> getListadoPersonas(){

            clsURIBase clsuri = new clsURIBase();
            Uri uri = null;
            uri = new Uri(clsuri.getUri()+"personas/");
            List<clsPersona> listaPersonas = new List<clsPersona>();

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try {
                //Send the GET request
                httpResponse = await httpClient.GetAsync(uri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                //deserializar
                if(httpResponse != null) {
                    listaPersonas = JsonConvert.DeserializableObject<List<clsPersona>>(httpResponse);
                }

            } catch (Exception ex) {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return listaPersonas;
        }

    }


}

