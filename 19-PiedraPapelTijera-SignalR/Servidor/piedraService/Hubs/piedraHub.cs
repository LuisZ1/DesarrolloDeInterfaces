using Microsoft.AspNet.SignalR;
using piedraService.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace piedraService.Hubs {
    public class piedraHub : Hub{

        List<jugada> listaJugadas = new List<jugada>();

        public void enviarJugada(jugada jugada) {
            //Clients.Others.broadcastMessage(jugada);

            listaJugadas.Add(jugada);

            if(listaJugadas.Count == 2) {
                String ganador = comprobarGanador();
                Clients.All.broadcastMessage(ganador);
            } else {
                //hacer que los clientes esperen
                Clients.Caller.waitAlOtro();
            }

        }

        private String comprobarGanador() {

            jugada newJugada = new jugada();
            newJugada.nombreJugador="pc";
            newJugada.jugadaHecha=2;
            listaJugadas.Add(newJugada);

            jugada jugadaMia = listaJugadas[0];
            jugada jugadaEnemigo = listaJugadas[1];

            // 1 piedra, 2 papel, 3 tijeras
            int enemyChoice = jugadaEnemigo.jugadaHecha;
            int userChoice = jugadaMia.jugadaHecha;

            String ganador = "Error";

            if (enemyChoice == 1) {
                if (userChoice == 1) {
                    Console.WriteLine("The computer chose rock");
                    Console.WriteLine("It is a tie ");
                    ganador = "Empate";
                } else if (userChoice == 2) {
                    Console.WriteLine("The computer chose paper");
                    Console.WriteLine("It is a tie ");
                    ganador = "Empate";
                } else if (userChoice == 3) {
                    Console.WriteLine("The computer chose scissors");
                    Console.WriteLine("It is a tie ");
                    ganador = "Empate";
                } else {
                    Console.WriteLine("You must choose rock,paper or scissors!");
                    ganador = "Elije uno!";
                }

            } else if (enemyChoice == 2) {
                if (userChoice == 1) {
                    Console.WriteLine("The computer chose paper");
                    Console.WriteLine("Sorry you lose,paper beat rock");
                    ganador = "gana " + jugadaEnemigo.nombreJugador;

                } else if (userChoice == 2) {
                    Console.WriteLine("The computer chose scissors");
                    Console.WriteLine("Sorry you lose,scissors beat paper ");
                    ganador = "gana " + jugadaEnemigo.nombreJugador;

                } else if (userChoice == 3) {
                    Console.WriteLine("The computer chose rock");
                    Console.WriteLine("Sorry you lose,rock beats scissors");
                    ganador = "gana " + jugadaEnemigo.nombreJugador;

                } else {
                    Console.WriteLine("You must choose rock,paper or scissors!");
                }
            } else if (enemyChoice == 3) {
                if (userChoice == 1) {
                    Console.WriteLine("The computer chose scissors");
                    Console.WriteLine("You win,rock beats scissors");
                    ganador = "gana " + jugadaMia.nombreJugador;

                } else if (userChoice == 2) {
                    Console.WriteLine("The computer chose rock");
                    Console.WriteLine("You win,paper beats rock");
                    ganador = "gana " + jugadaMia.nombreJugador;

                } else if (userChoice == 3) {
                    Console.WriteLine("The computer chose paper");
                    Console.WriteLine("You win,scissors beat paper");
                    ganador = "gana " + jugadaMia.nombreJugador;

                } else {
                    Console.WriteLine("You must choose rock,paper or scissors!");

                }

            }

            return ganador;
        }

    }
}