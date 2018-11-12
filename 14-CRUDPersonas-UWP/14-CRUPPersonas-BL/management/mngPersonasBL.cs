using _14_CRUPPersonas_Entities;
using _14_CRUPPersonas_DAL.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUPPersonas_BL.management {
    public class mngPersonasBL {

        /// <summary>
        /// devuelve un objeto persona, cuyo id corresponda al recibido
        /// si no lo encuentra el id es 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns>un obj persona</returns>
        public clsPersona getPersonoID_BL(int id) {

            mngPersonasDAL manejadora = new mngPersonasDAL();
            clsPersona persona = new clsPersona();

            persona = manejadora.getPersonaID_DAL(id);

            return persona;
        }

        /// <summary>
        /// elimina una persona de la base de datos, cuyo id corresponda al recibido
        /// si no lo encuentra el id es 0.
        /// llamando al metodo de la capa DAL
        /// si no borra nada devuelve -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns>un obj persona</returns>
        public int dropPersonoID_BL(int id) {

            mngPersonasDAL manejadora = new mngPersonasDAL();
            int numberOfDeletes = -1;

            numberOfDeletes = manejadora.dropPersonaID_DAL(id);

            return numberOfDeletes;
        }

        /// <summary>
        /// inserta una nueva persona llamando al metodo del capa DAL
        /// si no ha insertado nada devuelve -1
        /// </summary>
        /// <param name="personaAInsertar"></param>
        /// <returns>filas afectadas</returns>
        public int insertPersona_BL(clsPersona personaAInsertar) {

            int numberOfRows = -1;
            mngPersonasDAL manejadora = new mngPersonasDAL();

            numberOfRows = manejadora.insertPersona_DAL(personaAInsertar);

            return numberOfRows;
        }

        public int alterPersona_BL(clsPersona personaAModificar) {

            int numberOfRows = -1;
            mngPersonasDAL manejadora = new mngPersonasDAL();

            numberOfRows = manejadora.alterPersona_DAL(personaAModificar);

            return numberOfRows;

        }
    }
}
