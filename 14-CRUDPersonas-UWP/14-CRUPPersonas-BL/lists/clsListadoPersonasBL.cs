using _14_CRUPPersonas_DAL.Lists;
using _14_CRUPPersonas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUPPersonas_BL.lists {
    public class clsListadoPersonas_BL {

        /// <summary>
        /// devuelve un listado de personas completo de la base de datos, llamando al metodo
        /// de la capa DAL
        /// </summary>
        /// <returns>un listado de personas</returns>
        public List<clsPersona> listadoCompletoPersonas_BL() {

            clsListadoPersonasDAL clsListDAL = new clsListadoPersonasDAL();
            List<clsPersona> lista = new List<clsPersona>();

            lista = clsListDAL.listadoCompletoPersonasDAL();

            return lista;
        }
    }
}
