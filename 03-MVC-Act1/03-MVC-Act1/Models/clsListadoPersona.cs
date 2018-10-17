using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVC_Act1.Models {
    public class clsListadoPersona {

        public List<clsPersona> listaPersonas () {
            
            List<clsPersona> lista = new List<clsPersona>();

            lista.Add(new clsPersona(1,"Juan","Moreno"));
            lista.Add(new clsPersona(2, "Antonio", "Guerrero"));
            lista.Add(new clsPersona(3, "Ernesto", "Sevilla"));
            lista.Add(new clsPersona(4, "Miguel", "leugiM"));
            lista.Add(new clsPersona(5, "Armando", "Pistolas"));

            return lista;
        }

    }
}