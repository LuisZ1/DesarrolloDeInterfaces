using _14_CRUPPersonas_BL.lists;
using _14_CRUPPersonas_BL.management;
using _14_CRUPPersonas_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUDPersonas_UWP.ViewModels {
    public class MainPageViewModel : clsVMBase {

        #region propiedades privadas

        private List<clsPersona> _ListadoDePersonas;
        private clsPersona _PersonaSeleccionada;
        private clsDepartamento _DepartamentoSeleccionado;

        private List<clsDepartamento> _ListadoDepartamentos;
        private clsListadoPersonas_BL _listadoPersonas_BL = new clsListadoPersonas_BL();

        private DelegateCommand _eliminarCommand;
        private DelegateCommand _actualizarListaCommand;
        private DelegateCommand _modificarPersonaCommand;
        private DelegateCommand _insertarPersonaCommand;

        private bool _esUnaInsercion = false;

        #endregion

        #region propiedades publicas
        //public event PropertyChangedEventHandler PropertyChanged;
        public String esVisibleFormulario { get; set; }

        public List<clsPersona> ListadoDePersonas {
            get { return _ListadoDePersonas; }
            set { _ListadoDePersonas = value; }
        }

        public List<clsDepartamento> ListadoDeDepartamentos {
            get { return _ListadoDepartamentos; }
            set { _ListadoDepartamentos = value; }
        }

        public clsPersona PersonaSeleccionada {
            get {
                return _PersonaSeleccionada;
            }
            set {
                esVisibleFormulario = "Visible";
                _esUnaInsercion = false; //Gracias a Gorge
                _PersonaSeleccionada = value;
                _eliminarCommand.RaiseCanExecuteChanged();
                _modificarPersonaCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSeleccionada");
                NotifyPropertyChanged("esVisibleFormulario");
            }
        }

        public clsDepartamento DepartamentoSeleccionado {
            get { return _DepartamentoSeleccionado; }
            set { _DepartamentoSeleccionado = value; NotifyPropertyChanged("DepartamentoSeleccionado"); }
        }

        #endregion

        #region constructores

        public MainPageViewModel() {
            //Cargar listado de personas
            //_ListadoDePersonas = clsListadoPersonas.listadoPersonas();
            _ListadoDePersonas = _listadoPersonas_BL.listadoCompletoPersonas_BL();
            esVisibleFormulario = "Collapsed";
        }
        #endregion

        #region otros métodos
        //Al  utilizar clsBase no se necesita
        //protected void OnPropertyChanged(string name) {
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null) {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}

        #region eliminar
        public DelegateCommand eliminarCommand {
            get {
                _eliminarCommand = new DelegateCommand(eliminarCommand_Executed, eliminarCommand_CanExecuted);
                return _eliminarCommand;
            }
        }

        private void eliminarCommand_Executed() {

            try {
                //Instanciar un objeto de la clase manejadora de personas de la BL
                mngPersonasBL manejadoraPersonas = new mngPersonasBL();
                manejadoraPersonas.dropPersonoID_BL(PersonaSeleccionada.idPersona);

                _ListadoDePersonas = _listadoPersonas_BL.listadoCompletoPersonas_BL();
                NotifyPropertyChanged("ListadoDePersonas");
            } catch (Exception) {
                //Lanzar mensaje, messagedialog con error
            }
        }

        private bool eliminarCommand_CanExecuted() {
            bool sePuedeEliminar = false;

            if (PersonaSeleccionada != null) {
                sePuedeEliminar = true;
            }

            return sePuedeEliminar;
        }

        #endregion

        #region actualizar
        public DelegateCommand actualizarListaCommand {
            get {
                _actualizarListaCommand = new DelegateCommand(actualizarListaCommand_Executed);
                return _actualizarListaCommand;
            }
        }

        public void actualizarListaCommand_Executed() {
            try {
                _ListadoDePersonas = _listadoPersonas_BL.listadoCompletoPersonas_BL();
                PersonaSeleccionada = null;
                NotifyPropertyChanged("ListadoDePersonas");
            } catch (Exception) {
                //Lanzar mensaje, messagedialog con error
            }
        }
        #endregion

        #region modificar
        public DelegateCommand modificarPersonaCommand {
            get {
                _modificarPersonaCommand = new DelegateCommand(modificarPersonaCommand_Executed, modificarPersonaCommand_CanExecuted);
                return _modificarPersonaCommand;
            }
        }

        public void modificarPersonaCommand_Executed() {
            mngPersonasBL manejadoraPersonas = new mngPersonasBL();
            if (!_esUnaInsercion) {
                try {
                    manejadoraPersonas.alterPersona_BL(PersonaSeleccionada);

                    _ListadoDePersonas = _listadoPersonas_BL.listadoCompletoPersonas_BL();
                    NotifyPropertyChanged("ListadoDePersonas");
                } catch (Exception) {
                    //Lanzar mensaje, messagedialog con error 
                }
            } else {
                try {
                    manejadoraPersonas.insertPersona_BL(PersonaSeleccionada);

                    _ListadoDePersonas = _listadoPersonas_BL.listadoCompletoPersonas_BL();
                    NotifyPropertyChanged("ListadoDePersonas");
                    _esUnaInsercion = false;
                } catch (Exception e) {
                    //Lanzar mensaje, messagedialog con error 
                }
            }
        }

        public bool modificarPersonaCommand_CanExecuted() {
            bool sePuedeGuardar = false;

            if (PersonaSeleccionada != null) {
                sePuedeGuardar = true;
            }

            return sePuedeGuardar;
        }
        #endregion

        #region crearNuevo
        public DelegateCommand insertarPersonaCommand {
            get {
                _insertarPersonaCommand = new DelegateCommand(insertarPersonaCommand_Executed);
                return _insertarPersonaCommand;
            }
        }

        public void insertarPersonaCommand_Executed() {
            try {
                mngPersonasBL manejadoraPersonas = new mngPersonasBL();
                PersonaSeleccionada = null; // Para quitar el foco de la lista
                PersonaSeleccionada = new clsPersona();
                _esUnaInsercion = true;
            } catch (Exception) {
                //Lanzar mensaje, messagedialog con error 
            }
        }
        #endregion

        #endregion
    }
}
