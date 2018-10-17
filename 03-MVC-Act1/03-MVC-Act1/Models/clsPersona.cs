using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVC_Act1.Models {
    public class clsPersona {

        #region atributos
        public int idPersona { get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }

        #endregion

        public clsPersona() {

        }

        public clsPersona(int idPersona, String nombre, String apellidos) {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

        public String toString() {
            return nombre + apellidos;
        }

    }

}