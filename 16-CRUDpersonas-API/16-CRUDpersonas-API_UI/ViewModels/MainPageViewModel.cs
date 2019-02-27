﻿using _16_CRUDpersonas_API_BL.lists;
using _16_CRUDpersonas_API_BL.management;
using _16_CRUDpersonas_API_Entities;
using _16_CRUDpersonas_API_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _16_CRUDpersonas_API_UI.ViewModels {
    public class MainPageViewModel : clsVMBase {


        #region propiedades privadas

        private List<clsPersona> _ListadoDePersonas;
        private List<clsPersona> _ListadoDePersonasCompleto;
        private clsPersona _PersonaSeleccionada;
        private clsDepartamento _DepartamentoSeleccionado;
        private String _textoBuscado;
        private String _resultadoBusqueda;

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
            set { _ListadoDePersonas = value;
                NotifyPropertyChanged("ListadoDePersonas");
            }
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

        public String textoBuscado {
            get {
                return _textoBuscado;
            }
            set {
                _textoBuscado = value;
                resultadoBusqueda = FiltrarListado(_textoBuscado) + " resultados";
                NotifyPropertyChanged("ListadoDePersonas");
                NotifyPropertyChanged("resultadoBusqueda");
                OcultarFormulario();
            }
        }

        public String resultadoBusqueda {
            get {
                return _resultadoBusqueda;
            }
            set {
                _resultadoBusqueda = value;
            }
        }

        #endregion

        #region constructores

        public MainPageViewModel() {
            //Cargar listado de personas
            //_ListadoDePersonas = clsListadoPersonas.listadoPersonas();
            //_ListadoDePersonas = _listadoPersonas_BL.getListadoPersonas_BL();
            //_ListadoDePersonasCompleto = _listadoPersonas_BL.getListadoPersonas_BL();
            cargarListados();
            esVisibleFormulario = "Collapsed";
        }


        public async void cargarListados() {
            _ListadoDePersonas = await _listadoPersonas_BL.getListadoPersonas_BL();
            _ListadoDePersonasCompleto = await _listadoPersonas_BL.getListadoPersonas_BL();

            NotifyPropertyChanged("ListadoDePersonas");
            NotifyPropertyChanged("ListadoDePersonasCompleto");
        }

        #endregion

        // ---- OTROS MÉTODOS ----

        #region eliminar
        public DelegateCommand eliminarCommand {
            get {
                _eliminarCommand = new DelegateCommand(eliminarCommand_Executed, eliminarCommand_CanExecuted);
                return _eliminarCommand;
            }
        }

        private async void eliminarCommand_Executed() {

            try {
                //Instanciar un objeto de la clase manejadora de personas de la BL
                mngPersonasBL manejadoraPersonas = new mngPersonasBL();
                manejadoraPersonas.dropPersonaID_BL(PersonaSeleccionada.idPersona);

                ContentDialog confirmarBorrado = new ContentDialog();

                confirmarBorrado.Title = "Eliminar";
                confirmarBorrado.Content = "Estas seguro de borrar?";
                confirmarBorrado.PrimaryButtonText = "Cancelar";
                confirmarBorrado.SecondaryButtonText = "Aceptar";

                ContentDialogResult resultado = await confirmarBorrado.ShowAsync();

                if (resultado == ContentDialogResult.Secondary) {
                    recargarListados();
                }

            } catch (Exception) {
                //Lanzar mensaje, messagedialog con error
            } finally {
                alternarVisibilidadFormulario();
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
                recargarListados();
                PersonaSeleccionada = null;
                NotifyPropertyChanged("ListadoDePersonas");
            } catch (Exception) {
                //Lanzar mensaje, messagedialog con error
            } finally {
                OcultarFormulario();
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

        public async void modificarPersonaCommand_Executed() {
            mngPersonasBL manejadoraPersonas = new mngPersonasBL();

            try {
                if (!_esUnaInsercion) {
                    manejadoraPersonas.alterPersona_BL(PersonaSeleccionada);
                } else {
                    manejadoraPersonas.insertPersona_BL(PersonaSeleccionada);
                    _esUnaInsercion = false;
                }

                ContentDialog confirmar = new ContentDialog();

                confirmar.Title = "Confirmación";
                confirmar.Content = "Cambios guardados con éxito";
                confirmar.PrimaryButtonText = "Aceptar";

                ContentDialogResult resultado = await confirmar.ShowAsync();
                recargarListados();

            } catch (Exception) {

            } finally {
                /*
                 * Tenemos dos opciones:
                 *      - Ocultar el formulario
                 *      - Mostrar el formulario y que la persona seleccionada sea la insertada
                 */
                OcultarFormulario();
            }

            //if (!_esUnaInsercion) {
            //    try {
            //        manejadoraPersonas.alterPersona_BL(PersonaSeleccionada);

            //        _ListadoDePersonas = _listadoPersonas_BL.listadoCompletoPersonas_BL();
            //        NotifyPropertyChanged("ListadoDePersonas");
            //    } catch (Exception) {
            //        //Lanzar mensaje, messagedialog con error 
            //    }
            //} else {
            //    try {
            //        manejadoraPersonas.insertPersona_BL(PersonaSeleccionada);

            //        _ListadoDePersonas = _listadoPersonas_BL.listadoCompletoPersonas_BL();
            //        NotifyPropertyChanged("ListadoDePersonas");
            //        _esUnaInsercion = false;
            //    } catch (Exception e) {
            //        //Lanzar mensaje, messagedialog con error 
            //    }
            //}
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
            } finally {
                MostrarFormulario();
            }
        }
        #endregion

        #region buscar

        private int FiltrarListado(String texto) {

            _ListadoDePersonas = new List<clsPersona>();
            _ListadoDePersonas = _ListadoDePersonasCompleto.Where(persona => persona.nombre.ToLower().Contains(texto.ToLower()) || persona.apellidos.ToLower().Contains(texto.ToLower())).ToList();

            return _ListadoDePersonas.Count();
        }

        #endregion

        #region otros

        public void alternarVisibilidadFormulario() {

            if (esVisibleFormulario.Equals("Visible")) {
                esVisibleFormulario = "Collapsed";
            } else {
                esVisibleFormulario = "Visible";
            }
            NotifyPropertyChanged("esVisibleFormulario");
        }

        public void MostrarFormulario() {
            esVisibleFormulario = "Visible";
            NotifyPropertyChanged("esVisibleFormulario");
        }

        public void OcultarFormulario() {
            esVisibleFormulario = "Collapsed";
            NotifyPropertyChanged("esVisibleFormulario");
        }

        public async void recargarListados() {
            _ListadoDePersonas = await _listadoPersonas_BL.getListadoPersonas_BL();
            _ListadoDePersonasCompleto = _ListadoDePersonas;
            NotifyPropertyChanged("ListadoDePersonas");
            NotifyPropertyChanged("ListadoDePersonasCompleto");
        }

        #endregion

    }
}