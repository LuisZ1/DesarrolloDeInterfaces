using _16_CRUDpersonas_API_DAL.lists;
using _16_CRUDpersonas_API_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_CRUDpersonas_API_BL.lists {
    public class clsListadoPersonas_BL {

        public async Task<List<clsPersona>> getListadoPersonas_BL() {

            clsListadoPersonas_DAL gestoraDal = new clsListadoPersonas_DAL();
            List<clsPersona> lista = await gestoraDal.getListadoPersonas();

            return lista;

        }

    }
}
