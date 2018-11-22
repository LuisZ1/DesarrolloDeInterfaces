using ExamenTrim1_UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTrim1_UI.Models {
    class clsCarta : clsVMBase {

        private Uri _UriFoto;

        public int idCarta { get; set; }
        public bool esBomba { get; set; }
        public Uri UriFoto {
            get { return _UriFoto; }
            set { _UriFoto = value;
                NotifyPropertyChanged("UriFoto");
            }
        }

        public bool estado { get; set; }
        

        public clsCarta(int idCarta, bool esBomba, Uri UriFoto, bool estado) {
            this.idCarta = idCarta;
            this.esBomba = esBomba;
            this.UriFoto = UriFoto;
            this.estado = estado;
        }

        public clsCarta() {
            this.idCarta = 0;
            this.esBomba = false;
            this.UriFoto = UriFoto;
            this.estado = false;
        }


    }
}
