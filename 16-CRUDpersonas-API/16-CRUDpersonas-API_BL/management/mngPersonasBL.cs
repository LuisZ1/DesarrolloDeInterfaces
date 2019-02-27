
using _16_CRUDpersonas_API_DAL.management;
using _16_CRUDpersonas_API_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_CRUDpersonas_API_BL.management {
    public class mngPersonasBL {

        /// <summary>
        /// devuelve un objeto persona, cuyo id corresponda al recibido
        /// si no lo encuentra el id es 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns>un obj persona</returns>
        public async Task<clsPersona> getPersonaID_BL(int id) {

            clsManejadoraPersonas_DAL manejadora = new clsManejadoraPersonas_DAL();
            clsPersona persona = new clsPersona();

            persona = await manejadora.personaPorID_DAL(id);

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
        public async Task<int> dropPersonaID_BL(int id) {

            clsManejadoraPersonas_DAL manejadora = new clsManejadoraPersonas_DAL();
            int numberOfDeletes = -1;

            numberOfDeletes = await manejadora.BorrarPersonaPorID_DAL(id);

            return numberOfDeletes;
        }

        /// <summary>
        /// inserta una nueva persona llamando al metodo del capa DAL
        /// si no ha insertado nada devuelve -1
        /// </summary>
        /// <param name="personaAInsertar"></param>
        /// <returns>filas afectadas</returns>
        public async Task<int> insertPersona_BL(clsPersona personaAInsertar) {

            int numberOfRows = -1;
            clsManejadoraPersonas_DAL manejadora = new clsManejadoraPersonas_DAL();

            numberOfRows = await manejadora.InsertarPersonaDAL(personaAInsertar);

            return numberOfRows;
        }

        public async Task<int> alterPersona_BL(clsPersona personaAModificar) {

            int numberOfRows = -1;
            clsManejadoraPersonas_DAL manejadora = new clsManejadoraPersonas_DAL();

            numberOfRows = await manejadora.actualizarPersonaDAL(personaAModificar);

            return numberOfRows;

        }
    }
}
