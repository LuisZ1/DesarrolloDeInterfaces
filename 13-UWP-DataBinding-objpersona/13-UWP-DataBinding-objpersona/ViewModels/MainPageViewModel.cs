using _03_MVC_Ejercicio1_PasarDatosALaVista.Models;
using _04_MVC_Ejercicio2_PasarDatosDesdelaVista.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_UWP_DataBinding_objpersona.ViewModels {
    public class MainPageViewModel : INotifyPropertyChanged {

        #region propiedades privadas

        private List<clsPersona> _ListadoDePersonas;
        private clsPersona _PersonaSeleccionada;
        private List<clsDepartamento> _ListadoDepartamentos;

        

        #endregion

        #region propiedades publicas
        public event PropertyChangedEventHandler PropertyChanged;

        public List<clsPersona> ListadoDePersonas {
            get {
                return _ListadoDePersonas;
            }
            set {
                _ListadoDePersonas = value;
            }
        }

        public clsPersona PersonaSeleccionada {
            get {
                return _PersonaSeleccionada;
            }
            set /*fernando apruebame*/{
                _PersonaSeleccionada = value;
                OnPropertyChanged("PersonaSeleccionada");
            }
        }

        public List<clsDepartamento> ListadoDepartamentos {
            get {
                return _ListadoDepartamentos;
            }
            set {
                _ListadoDepartamentos = value;
            }
        }

        #endregion

        #region constructores

        public MainPageViewModel() {
            //Cargar listado de personas
            _ListadoDePersonas = clsListadoPersonas.listadoPersonas();
        }
        #endregion

        #region otros
        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
