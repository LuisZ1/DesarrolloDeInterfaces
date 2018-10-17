using _03_MVC_Act1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_MVC_Act1.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            clsPersona oPersona = new clsPersona();
            oPersona.idPersona = 1;
            oPersona.nombre = "Fernando";
            oPersona.apellidos = "Galiana";
            oPersona.fechaNacimiento = new DateTime (1973,10,10);
            oPersona.direccion = "Mi calle";
            oPersona.telefono = "98787654";
            
            
            ViewData["Saludo"] = saludito();
            //return View();
            return View(oPersona);
        }

        public ActionResult vistaListado() {
            clsListadoPersona lista = new clsListadoPersona();

            return View(lista);
        }

        /// <summary>
        /// metodo para saludar segun la hora actual
        /// </summary>
        /// <returns>una cadena de texto dependiendo de la hora actual</returns>
        public String saludito() {
            String saludo = "";

            String currentTime = DateTime.Now.ToShortTimeString();
            String[] horaString = currentTime.Split(':');
            int horaInt = Int32.Parse(horaString[0]);

            if (horaInt < 12) {
                saludo = "buenos días";
            } else {
                if (horaInt < 20) {
                    saludo = "buenas tardes";
                } else {
                    saludo = "buenas noches";
                }
            }

            return saludo;
        }

       
    }
}