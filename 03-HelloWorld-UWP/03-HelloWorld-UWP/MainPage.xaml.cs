using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _03_HelloWorld_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e) {

        }
        /// <summary>
        /// Realiza una llamada a una función asíncrona que se llama
        /// Button_Tap()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Tapped(object sender, RoutedEventArgs e) {
            Button_Tap();
        }
        /// <summary>
        /// Lanza un ContentaDialog con un saludo, usando el contenido
        /// de dos TextBox
        /// </summary>
        private async void Button_Tap() {
            ContentDialog noWifiDialog = new ContentDialog {
                Title = "Saludamos porque somos educados",
                Content = $"Hola {txtNombre.Text} {txtApellidos.Text}",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
    }
}
