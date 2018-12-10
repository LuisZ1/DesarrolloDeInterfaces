using System;
using System.Collections.Generic;

namespace _16_CRUDpersonas_API_Entities {
    public class clsDepartamento
    {

        #region atributos

        public String nombre { get; set; }
        public int ID { get; set; }


        #endregion



        #region constructores

        public clsDepartamento(String nombre, int ID) {

            this.nombre = nombre;
            this.ID = ID;

        }


        public clsDepartamento()
        {

            this.nombre = "";
            this.ID = 0;

        }

        #endregion


    }
}