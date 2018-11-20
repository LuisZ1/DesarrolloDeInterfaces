﻿using _14_CRUPPersonas_Entities;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _14_CRUDPersonas_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Quita el foco de los cuadros de texto antes de guardar
        /// 
        /// No se necesita si se utiliza, en el xaml, 
        /// la propiedad "UpdateSourceTrigger=PropertyChanged" en el binding
        /// </summary>
        //public void btnGuardar_Click() {
        //    txtNombre.Focus(FocusState.Unfocused);
        //    txtApellidos.Focus(FocusState.Unfocused);
        //    txtDireccion.Focus(FocusState.Unfocused);
        //    txtfechaNacimiento.Focus(FocusState.Unfocused);
        //    txtTelefono.Focus(FocusState.Unfocused);
        //}
        public void btnNuevo_Click(object sender, RoutedEventArgs e) {
            //txtNombre.Focus(FocusState.Unfocused);
            listilla.Focus(FocusState.Unfocused);
        }

        private void listilla_RightTapped(object sender, RightTappedRoutedEventArgs e) {
            ListView listView = (ListView)sender;

            miMenuFlyoutListado.ShowAt(listView, e.GetPosition(listView));
            clsPersona personaSeleccionada = (clsPersona)((FrameworkElement)e.OriginalSource).DataContext;
            this.listilla.SelectedItem = personaSeleccionada;
        }
        
    }
}
