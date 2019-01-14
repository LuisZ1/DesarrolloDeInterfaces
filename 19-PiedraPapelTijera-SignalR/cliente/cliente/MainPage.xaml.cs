using cliente.DataObjects;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace cliente {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        public HubConnection conn { get; set; }
        public IHubProxy proxy { get; set; }
        public piedraViewModel miVM { get; set; } = new piedraViewModel();
        Boolean seleccionado = false;

        jugada miJugada = new jugada();

        public MainPage() {
            this.InitializeComponent();
            //this.Suspending += OnSuspending;
            btn_Enviar.IsEnabled = false;
            SignalR();

        }

        private void btn_piedraClick(object sender, RoutedEventArgs e) {
            miJugada.nombreJugador = txtbox_nombreJugador.Text;
            miJugada.jugadaHecha = 1;
            seleccionado = true;
            btn_Enviar.IsEnabled = true;
            txt_ganador.Text = "selecionado piedra";
        }

        private void btn_papelClick(object sender, RoutedEventArgs e) {
            miJugada.nombreJugador = txtbox_nombreJugador.Text;
            miJugada.jugadaHecha = 2;
            seleccionado = true;
            btn_Enviar.IsEnabled = true;
            txt_ganador.Text = "selecionado papel";
        }

        private void btn_tijeraClick(object sender, RoutedEventArgs e) {
            miJugada.nombreJugador = txtbox_nombreJugador.Text;
            miJugada.jugadaHecha = 3;
            seleccionado = true;
            btn_Enviar.IsEnabled = true;
            txt_ganador.Text = "selecionado tijera";
        }

        private void btn_EnviarClick(object sender, RoutedEventArgs e) {
            if (seleccionado) {
                txt_ganador.Text = "enviado";
                proxy.Invoke("enviarJugada", miJugada);
            } else {
                txt_ganador.Text = "seleciona argoh";
            }
        }

        public void SignalR() {
            conn = new HubConnection("http://piedra.azurewebsites.net/");
            //conn = new HubConnection("http://localhost:50008/");
            proxy = conn.CreateHubProxy("piedraHub");
            conn.Start();

            proxy.On("waitAlOtro", waitAlOtro);
            proxy.On<String>("broadcastMessage", Broadcast);
        }

        public async void Broadcast(String resultado) {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                txt_ganador.Text = resultado;
                btn_Enviar.IsEnabled = true;
            });
        }

        public async void waitAlOtro() {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () => {
                btn_Enviar.IsEnabled = false;
                txt_ganador.Text = "Esperando al otro";
            }
            );
        }
    }
}
