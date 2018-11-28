using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _14_CRUDPersonas_UWP.ViewModels.Converters {
    public class clsConversorFechaCorta : IValueConverter{
        public object Convert(object value, Type targetType, object parameter, string language) {

            //DateTime fecha = (DateTime)value;
            int i = 00;
            DateTime dt = DateTime.Parse(value.ToString());
            return dt.ToString("dd/MM/yyyy");

            //return fecha.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {

            DateTime resultado;

            DateTime.TryParse((String)value, out resultado);

            return resultado;
        }
    }
}
