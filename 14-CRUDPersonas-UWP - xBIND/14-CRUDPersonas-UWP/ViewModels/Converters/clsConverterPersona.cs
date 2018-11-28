using _14_CRUPPersonas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_CRUDPersonas_UWP.ViewModels.Converters
{
    class clsConverterPersona
    {
        public object Convert(object value, Type targetType, object parameter, string language) {

            clsPersona oPersona = null;
            if (value != null) {
                oPersona = (clsPersona)value;
            }

            return oPersona;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {

            return value;
        }
    }
}
