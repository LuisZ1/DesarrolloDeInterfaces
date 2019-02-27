using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_CRUDpersonas_API_DAL.connection {
    public class clsURIBase {

        private String _uriBase = "https://07-apirest-personasapi20190109110824.azurewebsites.net/api/personas";

        public String getUri () { 
            return _uriBase;
        }

    }
}
