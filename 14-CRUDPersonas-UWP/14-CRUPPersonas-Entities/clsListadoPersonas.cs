using System;
using System.Collections.Generic;

namespace _14_CRUPPersonas_Entities {
    public class clsListadoPersonas
    {

        /// <summary>
        /// Metodo que devolvera una lista de objetos persona con datos predefinidos
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> listadoPersonas() {

             List<clsPersona> listado = new List<clsPersona>();

            listado.Add(new clsPersona(1, "Jorge", "Obando Lopez", new DateTime(1998, 10, 9), "Calle patata", "1111111"));
            listado.Add(new clsPersona(2, "Gorge", "Obandino Lopecio", new DateTime(1998, 10, 9), "Calle botella", "1111111"));
            listado.Add(new clsPersona(3, "Jorgue", "Hovando Pezlo", new DateTime(1998, 10, 9), "Calle alberto", "1111111"));
            listado.Add(new clsPersona(3, "Juan", "Moreno Poza", new DateTime(1998, 10, 9), "Calle falsa", "1111111"));
            listado.Add(new clsPersona(3, "Alberto", "Rezno Ploter", new DateTime(1998, 10, 9), "Calle almibar", "1111111"));
            listado.Add(new clsPersona(3, "Quisquilla", "Pelusa Po", new DateTime(1998, 10, 9), "Calle estiercol", "1111111"));

         

            return listado;


        }

    }
}