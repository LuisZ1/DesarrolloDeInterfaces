using Microsoft.AspNet.SignalR;
using piedraService.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace piedraService.Hubs {
    public class piedraHub : Hub {

        //    uuy06pjip0A30uszwgDh65JMmaBHHLtuoKXpDwCEw2igscz0x4fpMmYlnsAG

        static List<jugada> listaJugadas = new List<jugada>();

        public void enviarJugada(jugada jugada) {

            if (listaJugadas.Count > 2) {
                listaJugadas.Clear();
            }

            //jugada mijugada = new jugada();
            //mijugada.nombreJugador = "pc";
            //mijugada.jugadaHecha = 1;

            //listaJugadas.Add(mijugada);

            listaJugadas.Add(jugada);

            if (listaJugadas.Count == 2) {
                String ganador = comprobarGanador();
                Clients.All.broadcastMessage(ganador);
            } else {
                //hacer que los clientes esperen
                Clients.Caller.waitAlOtro();
            }
        }

        private String comprobarGanador() {

            jugada jugadaMia = listaJugadas[0];
            jugada jugadaEnemigo = listaJugadas[1];

            // 1 piedra, 2 papel, 3 tijeras
            int enemyChoice = jugadaEnemigo.jugadaHecha;
            int userChoice = jugadaMia.jugadaHecha;

            String ganador = "Error";

            if (enemyChoice == 1) { //Piedra
                if (userChoice == 1) { //piedra
                    ganador = "Empate los dos piedra";
                } else if (userChoice == 2) { //papel
                    ganador = jugadaMia.nombreJugador + " ha sacado papel, " + jugadaEnemigo.nombreJugador + " ha sacado piedra";
                    ganador = ganador + ". Gana " + jugadaMia.nombreJugador;
                } else if (userChoice == 3) { //tijera
                    ganador = jugadaMia.nombreJugador + " ha sacado tijera, " + jugadaEnemigo.nombreJugador + " ha sacado piedra";
                    ganador = ganador + ". Gana " + jugadaEnemigo.nombreJugador;
                } else {
                    Console.WriteLine("You must choose rock,paper or scissors!");
                    ganador = "ERROR 0";
                }

            } else if (enemyChoice == 2) { //papel
                if (userChoice == 1) { //piedra
                    ganador = jugadaMia.nombreJugador + " ha sacado piedra, " + jugadaEnemigo.nombreJugador + " ha sacado papel";
                    ganador = ganador+". Gana " + jugadaEnemigo.nombreJugador;

                } else if (userChoice == 2) { //papel
                    ganador = "Empate, los dos papel";

                } else if (userChoice == 3) { //tijera
                    ganador = jugadaMia.nombreJugador + " ha sacado tijera, " + jugadaEnemigo.nombreJugador + " ha sacado papel";
                    ganador = ganador+ ". Gana " + jugadaMia.nombreJugador;

                } else {
                    Console.WriteLine("You must choose rock,paper or scissors!");
                    ganador = "ERROR 1";
                }
            } else if (enemyChoice == 3) { //tijera
                if (userChoice == 1) { //piedra
                    ganador = jugadaMia.nombreJugador + " ha sacado piedra, " + jugadaEnemigo.nombreJugador + " ha sacado tijera";
                    ganador = ganador+". Gana " + jugadaMia.nombreJugador;

                } else if (userChoice == 2) { //papel
                    ganador = jugadaMia.nombreJugador + " ha sacado papel, " + jugadaEnemigo.nombreJugador + " ha sacado tijera";
                    ganador = ganador+". Gana " + jugadaEnemigo.nombreJugador;

                } else if (userChoice == 3) { //tijera
                    ganador = "Empate los dos tijera";

                } else {
                    Console.WriteLine("You must choose rock,paper or scissors!");
                    ganador = "ERROR 2";
                }
            }
            listaJugadas.Clear();
            return ganador;
        }

    }
}