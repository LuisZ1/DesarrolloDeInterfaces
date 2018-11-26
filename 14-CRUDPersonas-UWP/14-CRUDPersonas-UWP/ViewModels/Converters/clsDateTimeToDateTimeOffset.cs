using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _14_CRUDPersonas_UWP.ViewModels.Converters {
    class clsDateTimeToDateTimeOffset : IValueConverter{
        public object Convert(object value, Type targetType, object parameter, string language) {
            DateTime fecha = (DateTime)value;
            return new DateTimeOffset(fecha);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            DateTimeOffset resultado;
            return resultado.DateTime;
        }
    }
}
