using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ExamenTrim1_UI.Models.ViewModels {
    class MainPageViewModel : clsVMBase {

        #region atributos privados

        private int numeroDeCartas = 16;
        private List<clsCarta> _listadoCartas;
        private clsCarta _cartaSelecionada;
        private int _contadorCartasLevantadas;
        private bool _haGanado;
        private bool _esReinicio = true;

        private DelegateCommand _nuevaPartidaCommand;
        private DelegateCommand _reiniciarPartidaCommand;

        #endregion

        #region atributos públicos

        public List<clsCarta> listadoCartas {
            get { return _listadoCartas; }
            set { _listadoCartas = value; }
        }

        public clsCarta cartaSeleccionada {
            get { return _cartaSelecionada; }
            set {
                _cartaSelecionada = value;
                if (_esReinicio) {
                    AlternarEstadoCarta();
                    NotifyPropertyChanged("cartaSelecionada");
                    NotifyPropertyChanged("listadoCartas");
                    NotifyPropertyChanged("contadorCartasLevantadas");
                }
                if (cartaSeleccionada.esBomba) {
                    MensajeLoser();
                } else {
                    if (contadorCartasLevantadas >= 5) {
                        MensajeWinner();
                    }
                }
            }
        }

        public int contadorCartasLevantadas {
            get { return _contadorCartasLevantadas; }
        }

        public bool haGanado {
            get { return _haGanado; }
        }

        #endregion

        #region constructores
        public MainPageViewModel() {
            rellenarListaCartas();
            BarajarCartas();
            int i = 0; //para los breakpoint
        }

        #endregion

        #region otros métodos

        #region gestion Cartas
        /// <summary>
        /// El método cambia el estado de la carta dependiendo del estado actual, 
        /// invirtiendolo
        /// </summary>
        public void AlternarEstadoCarta() {
            if (cartaSeleccionada.estado) {
                OcultarCarta();
            } else {
                MostrarCarta();
            }
        }

        /// <summary>
        /// Cambia el estado de la carta a oculto
        /// </summary>
        private void OcultarCarta() {
            cartaSeleccionada.estado = false;
            cartaSeleccionada.UriFoto = new Uri("ms-appx://_ExamenTrim1-UI/Assets/Imagenes/presionar.png");
        }

        /// <summary>
        /// cambia el estado de la carta a Visible, cambiando la imagen por la que le corresponde
        /// y su estado a visible (true)
        /// </summary>
        private void MostrarCarta() {

            cartaSeleccionada.estado = true;
            _contadorCartasLevantadas = contadorCartasLevantadas + 1;

            if (cartaSeleccionada.esBomba) {
                cartaSeleccionada.UriFoto = new Uri("ms-appx://_ExamenTrim1-UI/Assets/Imagenes/bomba.png");
                _haGanado = false;
            } else {
                cartaSeleccionada.UriFoto = new Uri("ms-appx://_ExamenTrim1-UI/Assets/Imagenes/salvado.png");
            }

            //listadoCartas.Where(carta => carta.idCarta == cartaSeleccionada.idCarta);
            int indexCarta = listadoCartas.FindIndex(carta => carta.idCarta == cartaSeleccionada.idCarta);
            listadoCartas[indexCarta] = cartaSeleccionada;
        }

        /// <summary>
        /// Baraja las cartas para que se ordenen aleatoriamente
        /// </summary>
        public void BarajarCartas() {  //NO FUNCIONA BIEN
            List<clsCarta> listaAux = new List<clsCarta>();

            List<int> listaNumero = new List<int>();
            Random miAleatorio = new Random();
            int numeroAleatorio = -1;

            for(int i = 0; i < listadoCartas.Count(); i++) { //NO FUNCIONA BIEN
                
                do {
                    numeroAleatorio = miAleatorio.Next(0, 16);
                } while (listaNumero.Contains(numeroAleatorio));

                listaNumero.Add(numeroAleatorio);
                listaAux.Add(listadoCartas[numeroAleatorio]);
            }
            listadoCartas = listaAux;
        }

        /// <summary>
        /// el metodo rellena el listado de cartas, 
        /// obteniendolo de la clase clsListadoDeCartas
        /// </summary>
        private void rellenarListaCartas() {
            clsListadoDeCartas clsListado = new clsListadoDeCartas(numeroDeCartas);
            listadoCartas = clsListado.listadoCartas;
        }

        #endregion

        #region gestion partida

        /// <summary>
        /// Crea una nueva partida
        /// </summary>
        public void NuevaPartida() {
           NuevaPartidaCommand_Executed();
        }

        #region commands nueva partida

        /// <summary>
        /// command para nueva partida
        /// </summary>
        public DelegateCommand NuevaPartidaCommand() {
            _nuevaPartidaCommand = new DelegateCommand(NuevaPartidaCommand_Executed);
            return _nuevaPartidaCommand;
        }

        /// <summary>
        /// executed command para nueva partida
        /// </summary>
        public void NuevaPartidaCommand_Executed() {
            rellenarListaCartas();
            NotifyPropertyChanged("listadoCartas");
        }

        #endregion

        /// <summary>
        /// Reinicia la partida actual, ocultando todas las cartas
        /// y reiniciando los contadores
        /// </summary>
        public void ReiniciarPartida() {
            ReiniciarPartidaCommand_Executed();
        }

        #region commands reiniciar partida

        /// <summary>
        /// command para reiniciar partida
        /// </summary>
        public DelegateCommand ReiniciarPartidaCommand() {
            _reiniciarPartidaCommand = new DelegateCommand(ReiniciarPartidaCommand_Executed);
            return _reiniciarPartidaCommand;
        }

        /// <summary>
        /// command executed para reiniciar partida
        /// </summary>
        public void ReiniciarPartidaCommand_Executed() {
            for (int i = 0; i < numeroDeCartas; i++) {
                listadoCartas[i].estado = false;
            }
            NotifyPropertyChanged("listadoCartas");
            _esReinicio = true;
        }

        #endregion


        public async void MensajeLoser() {
            ContentDialog confirmar = new ContentDialog();

            confirmar.Title = "Has perdido";
            confirmar.Content = "Oh, has pulsado una bomba, has perdido la partida";
            confirmar.PrimaryButtonText = "Nueva partida";
            confirmar.SecondaryButtonText = "Reiniciar partida";

            ContentDialogResult resultado = await confirmar.ShowAsync();

            if (resultado == ContentDialogResult.Secondary) {
                //ReiniciarPartida();
                ReiniciarPartidaCommand_Executed();
            } else {
                NuevaPartida();
            }
        }

        public async void MensajeWinner() {
            ContentDialog confirmar = new ContentDialog();

            confirmar.Title = "GANADOR";
            confirmar.Content = "Enhorabuena, has ganado la partida";
            confirmar.PrimaryButtonText = "Nueva partida";

            ContentDialogResult resultado = await confirmar.ShowAsync();

            NuevaPartida();

        }

        #endregion

        #endregion

    }
}
