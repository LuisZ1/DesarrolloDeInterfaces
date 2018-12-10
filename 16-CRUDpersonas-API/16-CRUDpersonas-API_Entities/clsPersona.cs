using System;
using System.Collections.Generic;

namespace _16_CRUDpersonas_API_Entities {
    public class clsPersona
    {
        #region atributosYPropiedades

        public int idPersona { get; set; }

        public String nombre { get; set; }

        public String apellidos { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public String direccion { get; set; }

        public String telefono { get; set; }

        public int idDepartamento { get; set; }


        #endregion


        #region constructores

        public clsPersona(int idPersona, String nombre, String apellidos, DateTime fechaNacimiento, String direccion, String telefono, int idDepartamento) {

            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.idDepartamento = idDepartamento;

        }

        public clsPersona() {

            this.idPersona = 0;
            this.nombre = "";
            this.apellidos = "";
            this.fechaNacimiento = new DateTime();
            this.direccion = "";
            this.telefono = "";
            this.idDepartamento = 1;
        }

        #endregion


    }
}