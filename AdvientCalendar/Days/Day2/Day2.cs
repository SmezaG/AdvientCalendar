using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public static class Day2
{
    public static void Part1()
    {
        string filePath = @"C:\Users\Usuario\source\repos\AdvientCalendar\AdvientCalendar\Days\Day2\Day2-imput.txt";
        string imputText = File.ReadAllText(filePath);
        string patronGameId = @"Game (\d+)";
        string patronPlay = @"(\d+)\s*([a-zA-Z]+)";
        List<int> numeros = new List<int>();
        List<Game> Games = new List<Game>();
        List<Colors> colors = new List<Colors>();
        List<Play> Partidas = new List<Play>();
        Game game;
        Play play;
        int maxRed = 12;
        int maxGreen = 13;
        int maxBlue= 14;
        bool imposible = false;
        int aswer = 0;


        string[] lineas = imputText.Split('\n');

        foreach(string linea in lineas)
        {
            Partidas = new List<Play>();
            Match match = Regex.Match(linea, patronGameId);
            string numeroStr = match.Groups[1].Value;
            game = new Game(int.Parse(numeroStr));

            List<string> listaStrings = new List<string>(linea.Split(';'));
            foreach(string partida in listaStrings)
            {
                colors = new List<Colors>();
                string p;
                p = partida.Replace($"Game {numeroStr}: ", "");

                MatchCollection matches = Regex.Matches(p, patronPlay);

                foreach (Match playMatch in matches)
                {
                    string numerocolor = playMatch.Groups[1].Value;
                    string color = playMatch.Groups[2].Value;
                    Colors c = new Colors(int.Parse(numerocolor), color);
                    colors.Add(c);
                }
                
                play = new Play(colors);
                Partidas.Add(play);


            }
            game.Partidas = Partidas;
            Games.Add(game);
        }


        foreach (Game g in Games)
        {
            imposible = false;
            foreach(Play p in g.Partidas)
            {
                foreach(Colors c in p.Colores)
                {
                    switch (c.Color)
                    {
                        case "green":
                            if (c.ColorNumber > maxGreen)
                            {
                                imposible = true;
                            }
                            break;
                        case "blue":
                            if (c.ColorNumber > maxBlue)
                            {
                                imposible = true;
                            }
                            break;
                        case "red":
                            if (c.ColorNumber > maxRed)
                            {
                                imposible = true;
                            }
                            break;
                    }
                }

            }

            if (imposible == false)
            {
                aswer += g.NumeroJuego;
            }
        }

        Console.WriteLine(aswer);

        

        //foreach (int n in numeros)
        //{
        //    Console.WriteLine(n);
        //}
    }

    public static void Part2()
    {
        string filePath = @"C:\Users\Usuario\source\repos\AdvientCalendar\AdvientCalendar\Days\Day2\Day2-imput.txt";
        string imputText = File.ReadAllText(filePath);
        string patronGameId = @"Game (\d+)";
        string patronPlay = @"(\d+)\s*([a-zA-Z]+)";
        List<int> numeros = new List<int>();
        List<Game> Games = new List<Game>();
        List<Colors> colors = new List<Colors>();
        List<Play> Partidas = new List<Play>();
        Game game;
        Play play;
        int minRed = 0;
        int minGreen = 0;
        int minBlue = 0;
        int multipliedgame = 0;
        int aswer = 0;


        string[] lineas = imputText.Split('\n');

        foreach (string linea in lineas)
        {
            Partidas = new List<Play>();
            Match match = Regex.Match(linea, patronGameId);
            string numeroStr = match.Groups[1].Value;
            game = new Game(int.Parse(numeroStr));

            List<string> listaStrings = new List<string>(linea.Split(';'));
            foreach (string partida in listaStrings)
            {
                colors = new List<Colors>();
                string p;
                p = partida.Replace($"Game {numeroStr}: ", "");

                MatchCollection matches = Regex.Matches(p, patronPlay);

                foreach (Match playMatch in matches)
                {
                    string numerocolor = playMatch.Groups[1].Value;
                    string color = playMatch.Groups[2].Value;
                    Colors c = new Colors(int.Parse(numerocolor), color);
                    colors.Add(c);
                }

                play = new Play(colors);
                Partidas.Add(play);


            }
            game.Partidas = Partidas;
            Games.Add(game);
        }


        foreach(Game g in Games)
        {

            minRed = 0;
            minGreen = 0;
            minBlue = 0;

            foreach (Play p in g.Partidas)
            {
                foreach(Colors c in p.Colores)
                {
                    switch (c.Color)
                    {
                        case "green":
                            if (c.ColorNumber > minGreen)
                            {
                                minGreen = c.ColorNumber;
                            }
                            break;
                        case "blue":
                            if (c.ColorNumber > minBlue)
                            {
                                minBlue = c.ColorNumber;
                            }
                            break;
                        case "red":
                            if (c.ColorNumber > minRed)
                            {
                                minRed = c.ColorNumber;
                            }
                            break;
                    }
                }
            }

            multipliedgame = minGreen * minBlue * minRed;
            aswer += multipliedgame;
        }


        Console.WriteLine(aswer);

    }


}