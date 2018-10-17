using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld_WindowsForms_cSharp
{
    /*
     Clase Persona
     Atributos: Nombre y apellidos (String)
     Metodos: --
         */
    public class clsPersona
    {
        #region "Atributos"
        //Atributos
        private String _nombre;
        private String _apellidos;
        #endregion

        #region "Constructores"
        //Constructores
        public clsPersona(){
            _nombre = " ";
            _apellidos = " ";
        }

        public clsPersona(String nombre1, String apellidos1){
            _nombre = nombre1;
            _apellidos = apellidos1;
        }
        #endregion

        #region "consultores y modificadores"
        public String nombre {
            get {
                return _nombre;
            }
            set {
                _nombre = nombre;
            }
        }

        public String apellidos {
            get {
                return _apellidos;
            }
            set {
                _apellidos = apellidos;
            }
        }
        #endregion

        #region "Modo Java"
        //metodos Consultores
        /*public String getNombre(){
            return nombre;
        }

        public String getApellidos()
        {
            return apellidos;
        }

        //metodos Modificadores
        public void setNombre(String nombre1) {
            nombre = nombre1;
        }
        public void setApellidos(String apellidos1) {
            nombre = apellidos1;
        }
        */
        #endregion
    }
}
