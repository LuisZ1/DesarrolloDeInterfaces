﻿#pragma checksum "C:\Users\lzumarraga\OneDrive\2018-19\Interfaces\Repositorio\Desarrollo de Interfaces\07-GridFormulario-UWP\07-GridFormulario-UWP\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "64FCFED8F728956CABC55A621DD5FAA4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _07_GridFormulario_UWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\MainPage.xaml line 11
                {
                    this.botonera = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // Views\MainPage.xaml line 17
                {
                    this.Formulario = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4: // Views\MainPage.xaml line 47
                {
                    this.btnSend = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSend).Click += this.btnSend_Click;
                }
                break;
            case 5: // Views\MainPage.xaml line 31
                {
                    this.txtNombre = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Views\MainPage.xaml line 32
                {
                    this.lblName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Views\MainPage.xaml line 35
                {
                    this.txtApellidos = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Views\MainPage.xaml line 36
                {
                    this.lblApellidos = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // Views\MainPage.xaml line 39
                {
                    this.txtFecha = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // Views\MainPage.xaml line 40
                {
                    this.lblFecha = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // Views\MainPage.xaml line 43
                {
                    this.txtEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // Views\MainPage.xaml line 44
                {
                    this.lblEmail = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
