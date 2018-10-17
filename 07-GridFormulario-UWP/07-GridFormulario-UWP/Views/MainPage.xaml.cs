using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _07_GridFormulario_UWP {
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        /// <summary>
        /// El metodo comprueba que los campos de texto no estén vacíos
        /// en caso de estarlo modifica un texto de error y si no están vacíos 
        /// pero el texto de error está escrito: borra el texto de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e) {
            bool formValido = true;
            DateTime temp;

            if (String.IsNullOrEmpty(txtNombre.Text)) {
                lblName.Text = "Nombre no puede estar vacío";
                formValido = false;
            } else {
                lblName.Text = "";
            }

            if (String.IsNullOrEmpty(txtApellidos.Text)) {
                lblApellidos.Text = "Apellidos no puede estar vacío";
                formValido = false;
            } else {
                lblApellidos.Text = "";
            }

            if (String.IsNullOrEmpty(txtFecha.Text)) {
                lblFecha.Text = "Fecha no puede estar vacío";
                formValido = false;
            } else {
                /*if (!Regex.IsMatch(txtEmail.Text, @"^ (?: (?: 31(\/| -|\.)(?:0?[13578] | 1[02]))\1 | 
                    (?: (?: 29 | 30)(\/| -|\.)(?:0?[1, 3 - 9] | 1[0 - 2])\2)) (?: (?: 1[6 - 9] 
                    |[2 - 9]\d)?\d{ 2})$|^ (?: 29(\/| -|\.)0 ? 2\3(?:(?: (?: 1[6 - 9] |[2 - 9]
                    \d) ? (?: 0[48] |[2468][048] |[13579][26]) | (?: (?: 16 |[2468][048] 
                    |[3579][26])00))))$|^ (?: 0?[1 - 9] | 1\d | 2[0 - 8])(\/| -|\.)(?: 
                    (?: 0?[1 - 9]) | (?: 1[0 - 2]))\4(?:(?: 1[6 - 9] |[2 - 9]\d) ?\d{ 2})$")) {
                    lblFecha.Text = "Fecha no válida";*/

                if (!DateTime.TryParse(txtFecha.Text, out temp)) { //Nay :(
                    lblFecha.Text = "Fecha no válida";
                    formValido = false;
                } else { // Yay :)
                    lblFecha.Text = "";
                }
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text)) {
                //DialogHelper.ShowToast(string.Empty, "The email is invalid");
                lblEmail.Text = "Email no puede estar vacío";
                formValido = false;
            } else {
                if (!Regex.IsMatch(txtEmail.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")) {
                    lblEmail.Text = "Email no valido";
                    formValido = false;
                } else {
                    lblEmail.Text = "";
                }
            }

            if (formValido == true) {
                //formulario enviado
                Mensajito("Formulario enviado correctamente");
            } else {
                //formulario no enviado
            }

        }

        private async void Mensajito(String mensaje) {
            var dialog = new MessageDialog(mensaje);
            await dialog.ShowAsync();
        }
    }
}
