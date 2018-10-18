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

namespace _09_UWP_Controles
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Initialize a new list of colors
            List<String> colors = new List<String>();

            // Put some colors to the list
            colors.Add("Red");
            colors.Add("Green");
            colors.Add("Blue");
            colors.Add("Yellow");
            colors.Add("Black");
            colors.Add("Olive");
            colors.Add("Pink");
            colors.Add("White");
            colors.Add("Magenta");

            // Finally, Specify the ComboBox items source
            ComboBox1.ItemsSource = colors;

            //Slider
            Slider volumeSlider = new Slider();
            volumeSlider.Header = "Volume";
            volumeSlider.Width = 200;
            volumeSlider.ValueChanged += Slider_ValueChanged;

            // Add the slider to a parent container in the visual tree.
            stackPanel1.Children.Add(volumeSlider);
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // Get the ComboBox instance
            ComboBox comboBox = sender as ComboBox;

            // Get the ComboBox selected item text and display on TextBlock
            TextBlock1.Text = "You selected:\n";
            TextBlock1.Text += comboBox.SelectedValue.ToString();
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e) {
            Slider slider = sender as Slider;
            /*if (slider != null) {
                media.Volume = slider.Value;
            }*/
        }
    }
}
