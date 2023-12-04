using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Game
    {

        public int NumeroJuego { get; set; }
        public List<Play> Partidas { get; set; }

        // Constructor
        public Game(int numeroJuego)
        {
            NumeroJuego = numeroJuego;
        }



    }

