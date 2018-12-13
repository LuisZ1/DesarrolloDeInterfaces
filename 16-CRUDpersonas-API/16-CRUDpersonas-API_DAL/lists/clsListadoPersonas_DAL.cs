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

            clsUriBase gestoriaApi = new clsUriBase();
            String uri = gestoriaApi.getUriBase();
            Uri UriApi = new Uri(uri);
            List<clsPersona> lista = null;
            string ret;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(UriApi);

            if (response.IsSuccessStatusCode) {
                ret = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<clsPersona>>(ret);
            } else {

            }

            return lista;
        }

    }


}

