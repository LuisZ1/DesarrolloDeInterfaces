using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _04_Botones_y_propiedades_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            createButton();

        }

        private void createButton() {
            //Creo el objeto Botonsito
            Button botonsito = new Button();

            //Colocarlo en la pantalla
            botonsito.Height = 70;
            botonsito.Width = 200;
            //botonsito.Location = new Point(3, 14);

            botonsito.Background = new SolidColorBrush(Colors.Red);
            botonsito.Foreground = new SolidColorBrush(Colors.White);
            botonsito.HorizontalAlignment = HorizontalAlignment.Center;
            botonsito.VerticalAlignment = VerticalAlignment.Center;

            botonsito.Content = "Botonsito 3";
            botonsito.Name = "DynamicButton";
            botonsito.BorderBrush = new SolidColorBrush(Colors.HotPink);
            //botonsito.Click += new this.btn_Click;

            Panel1.Children.Add(botonsito);
        }
 
        private void btn_Click(object sender, EventArgs e) {
            //
        }
    }
}
