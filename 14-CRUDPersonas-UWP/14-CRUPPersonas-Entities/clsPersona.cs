using System;
using System.Collections.Generic;

namespace _14_CRUPPersonas_Entities {
    public class clsPersona
    {
        #region atributosYPropiedades

        public int idPersona { get; set; }

        public String nombre { get; set; }

        public String apellidos { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public String direccion { get; set; }

        public String telefono { get; set; }


        #endregion


        #region constructores

        public clsPersona(int idPersona, String nombre, String apellidos, DateTime fechaNacimiento, String direccion, String telefono) {

            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;

        }

        public clsPersona() {

            this.idPersona = 0;
            this.nombre = "";
            this.apellidos = "";
            this.fechaNacimiento = new DateTime();
            this.direccion = "";
            this.telefono = "";

        }

        #endregion


    }
}