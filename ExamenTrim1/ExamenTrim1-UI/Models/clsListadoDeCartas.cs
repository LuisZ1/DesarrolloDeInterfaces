using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTrim1_UI.Models {
    class clsListadoDeCartas {

        public List<clsCarta> listadoCartas = new List<clsCarta>();

        public clsListadoDeCartas(int nCartas) {
            rellenarListaConCartas(nCartas);
        }

        public void rellenarListaConCartas(int numeroARellenar) {

            int contadorIDCarta = 1;
            int lastID = 0;

            Uri UriFotoCarta = new Uri("ms-appx://_ExamenTrim1-UI/Assets/Imagenes/presionar.png");

            for (contadorIDCarta=1;contadorIDCarta<numeroARellenar-4;contadorIDCarta++) {
                clsCarta cartaBuena = new clsCarta(contadorIDCarta, false, UriFotoCarta, false);
                listadoCartas.Add(cartaBuena);
                lastID = contadorIDCarta;
            }
            
            for (contadorIDCarta = lastID; contadorIDCarta < numeroARellenar; contadorIDCarta++) {
                clsCarta cartaBomba = new clsCarta(contadorIDCarta, true, UriFotoCarta, false);
                listadoCartas.Add(cartaBomba);
            }
        }
    }
}

