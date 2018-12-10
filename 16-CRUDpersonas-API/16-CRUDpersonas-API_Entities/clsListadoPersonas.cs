using System;
using System.Collections.Generic;

namespace _16_CRUDpersonas_API_Entities {
    public class clsListadoPersonas
    {

        /// <summary>
        /// Metodo que devolvera una lista de objetos persona con datos predefinidos
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> listadoPersonas() {

             List<clsPersona> listado = new List<clsPersona>();

            listado.Add(new clsPersona(1, "Jorge", "Obando Lopez", new DateTime(1998, 10, 9), "Calle patata", "1111111",2));
            listado.Add(new clsPersona(2, "Gorge", "Obandino Lopecio", new DateTime(1998, 10, 9), "Calle botella", "1111111",3));
            listado.Add(new clsPersona(3, "Jorgue", "Hovando Pezlo", new DateTime(1998, 10, 9), "Calle alberto", "1111111",1));
            listado.Add(new clsPersona(4, "Juan", "Moreno Poza", new DateTime(1998, 10, 9), "Calle falsa", "1111111",1));
            listado.Add(new clsPersona(5, "Alberto", "Rezno Ploter", new DateTime(1998, 10, 9), "Calle almibar", "1111111",3));
            listado.Add(new clsPersona(6, "Quisquilla", "Pelusa Po", new DateTime(1998, 10, 9), "Calle estiercol", "1111111",1));
            listado.Add(new clsPersona(7, "Jorge", "Obando Lopez", new DateTime(1998, 10, 9), "Calle patata", "1111111", 2));
            listado.Add(new clsPersona(8, "Gorge", "Obandino Lopecio", new DateTime(1998, 10, 9), "Calle botella", "1111111", 3));
            listado.Add(new clsPersona(9, "Jorgue", "Hovando Pezlo", new DateTime(1998, 10, 9), "Calle alberto", "1111111", 1));
            listado.Add(new clsPersona(10, "Juan", "Moreno Poza", new DateTime(1998, 10, 9), "Calle falsa", "1111111", 1));
            listado.Add(new clsPersona(11, "Alberto", "Rezno Ploter", new DateTime(1998, 10, 9), "Calle almibar", "1111111", 3));
            listado.Add(new clsPersona(12, "Quisquilla", "Pelusa Po", new DateTime(1998, 10, 9), "Calle estiercol", "1111111", 1));
            listado.Add(new clsPersona(13, "Jorge", "Obando Lopez", new DateTime(1998, 10, 9), "Calle patata", "1111111", 2));
            listado.Add(new clsPersona(14, "Gorge", "Obandino Lopecio", new DateTime(1998, 10, 9), "Calle botella", "1111111", 3));
            listado.Add(new clsPersona(15, "Jorgue", "Hovando Pezlo", new DateTime(1998, 10, 9), "Calle alberto", "1111111", 1));
            listado.Add(new clsPersona(16, "Juan", "Moreno Poza", new DateTime(1998, 10, 9), "Calle falsa", "1111111", 1));
            listado.Add(new clsPersona(17, "Alberto", "Rezno Ploter", new DateTime(1998, 10, 9), "Calle almibar", "1111111", 3));
            listado.Add(new clsPersona(18, "Quisquilla", "Pelusa Po", new DateTime(1998, 10, 9), "Calle estiercol", "1111111", 1));



            return listado;


        }

    }
}