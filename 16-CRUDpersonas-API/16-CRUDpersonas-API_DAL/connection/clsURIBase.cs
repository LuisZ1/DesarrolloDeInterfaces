using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_CRUDpersonas_API_DAL.connection {
    public class clsURIBase {

        private String _uriBase = "https://apirestpersonaslz.azurewebsites.net/api/";

        public String getUri () { 
            return _uriBase;
        }

    }
}
