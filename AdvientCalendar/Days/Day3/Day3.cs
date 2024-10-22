﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;


static class Day3
{

    public static void Part1()
    {

        string filePath = @"C:\Users\Usuario\source\repos\AdvientCalendar\AdvientCalendar\Days\Day3\Day3-imput.txt";
        string imputText = File.ReadAllText(filePath);
        string number = "";
        int numberOut = 0;
        int answer = 0;



        string[] lineas = imputText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        char[,] matriz = new char[lineas.Length, lineas.Max(l => l.Length)];

        for (int i = 0; i < lineas.Length; i++)
        {
            char[] caracteres = lineas[i].ToCharArray();
            for (int j = 0; j < caracteres.Length; j++)
            {
                matriz[i, j] = caracteres[j];
            }
        }

        for (int i = 0; i < matriz.GetLength(0); i++)
        {

            number = "";
            for (int j = 0; j < matriz.GetLength(1); j++)
            {

                if (int.TryParse(matriz[i, j].ToString(), out numberOut))
                {
                    number = number + numberOut.ToString();
                }
                else
                {
                    if (number.Length > 0)
                    {
                        (int x, int y) minCoord = (i, j - number.Length);
                        (int x, int y) maxCoord = (i, j - 1);
                        if (CompruebaNumeroValido(matriz, minCoord, maxCoord))
                        {
                            answer = answer + int.Parse(number);
                        }
                    }

                    number = "";
                }

                if (matriz.GetLength(1) - 1 == j)
                {
                    if (number.Length > 0)
                    {
                        (int x, int y) minCoord = (i, j - (number.Length - 1));
                        (int x, int y) maxCoord = (i, j);
                        if (CompruebaNumeroValido(matriz, minCoord, maxCoord))
                        {
                            answer = answer + int.Parse(number);
                        }
                    }
                }

            }
        }


        Console.WriteLine(answer);



    }


    public static void Part2()
    {


        //string filePath = @"C:\Users\Usuario\source\repos\AdvientCalendar\AdvientCalendar\Days\Day3\Day3-imput.txt";
        string filePath = @"C:\Users\smeza\source\repos\SmezaG\AdvientCalendar\AdvientCalendar\Days\Day3";
        string imputText = File.ReadAllText(filePath);
        string number = "";
        int numberOut = 0;
        int answer = 0;
        Dictionary<(int, int), List<int>> diccCoord = new Dictionary<(int, int), List<int>>();




        string[] lineas = imputText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        char[,] matriz = new char[lineas.Length, lineas.Max(l => l.Length)];

        for (int i = 0; i < lineas.Length; i++)
        {
            char[] caracteres = lineas[i].ToCharArray();
            for (int j = 0; j < caracteres.Length; j++)
            {
                matriz[i, j] = caracteres[j];
            }
        }


        for (int i = 0; i < matriz.GetLength(0); i++)
        {

            number = "";
            for (int j = 0; j < matriz.GetLength(1); j++)
            {

                if (int.TryParse(matriz[i, j].ToString(), out numberOut))
                {
                    number = number + numberOut.ToString();
                }
                else
                {
                    if (number.Length > 0)
                    {
                        (int x, int y) minCoord = (i, j - number.Length);
                        (int x, int y) maxCoord = (i, j - 1);
                        CompruebaNumeroValidoPart2(matriz, minCoord, maxCoord, number, ref diccCoord);
                    }

                    number = "";
                }

                if (matriz.GetLength(1) - 1 == j)
                {
                    if (number.Length > 0)
                    {
                        (int x, int y) minCoord = (i, j - (number.Length - 1));
                        (int x, int y) maxCoord = (i, j);
                        CompruebaNumeroValidoPart2(matriz, minCoord, maxCoord, number, ref diccCoord);
           
                    }
                }

            }
        }


        //Console.WriteLine(answer);


    }


    public static bool CompruebaNumeroValido(char[,] matriz, (int x, int y) minCoord, (int x, int y) maxCoord)
    {
        int number;
        bool res = false;
        int fila = 0;
        int columna = 0;
        //X469
        fila = minCoord.x;
        columna = minCoord.y - 1;
        if (fila >= 0 && fila < matriz.GetLength(0) && columna >= 0 && columna < matriz.GetLength(1))
        {
            if (!int.TryParse(matriz[fila, columna].ToString(), out number))
            {
                if (matriz[fila, columna].ToString() != ".")
                {
                    res = true;
                    return res;
                }
            }
        }

        //469X

        fila = maxCoord.x;
        columna = maxCoord.y + 1;
        if (fila >= 0 && fila < matriz.GetLength(0) && columna >= 0 && columna < matriz.GetLength(1))
        {
            if (!int.TryParse(matriz[fila, columna].ToString(), out number))
            {
                if (matriz[fila, columna].ToString() != ".")
                {
                    res = true;
                    return res;
                }
            }
        }


        //XXXXX
        // 469
        //XXXXX
        List<int> coordToCheck = new List<int>();
        for (int i = minCoord.y - 1; i <= maxCoord.y + 1; i++)
        {
            coordToCheck.Add(i);
        }

        foreach (int coord in coordToCheck)
        {
            fila = maxCoord.x - 1;
            columna = coord;
            if (fila >= 0 && fila < matriz.GetLength(0) && columna >= 0 && columna < matriz.GetLength(1))
            {
                if (!int.TryParse(matriz[fila, columna].ToString(), out number))
                {
                    if (matriz[fila, columna].ToString() != ".")
                    {
                        res = true;
                        return res;
                    }
                }
            }


            fila = maxCoord.x + 1;
            columna = coord;
            if (fila >= 0 && fila < matriz.GetLength(0) && columna >= 0 && columna < matriz.GetLength(1))
            {
                if (!int.TryParse(matriz[fila, columna].ToString(), out number))
                {
                    if (matriz[fila, columna].ToString() != ".")
                    {
                        res = true;
                        return res;
                    }
                }
            }

           
        }



        return res;
    }


    public static bool CompruebaNumeroValidoPart2(char[,] matriz, (int x, int y) minCoord, (int x, int y) maxCoord, string numberParam, ref Dictionary<(int, int), List<int>> diccCoord)
    {
        int number;
        bool res = false;
        int fila = 0;
        int columna = 0;

        //X469
        fila = minCoord.x;
        columna = minCoord.y - 1;
        if (fila >= 0 && fila < matriz.GetLength(0) && columna >= 0 && columna < matriz.GetLength(1))
        {
            if (!int.TryParse(matriz[fila, columna].ToString(), out number))
            {
                if (matriz[fila, columna].ToString() == "*")
                {
                    var claveABuscar = (fila, columna);
                    if (diccCoord.ContainsKey(claveABuscar))
                    {
                        diccCoord[claveABuscar].Add(int.Parse(numberParam));
                    }
                    else
                    {
                        diccCoord[claveABuscar] = new List<int> { int.Parse(numberParam) };
                    }

                    res = true;
                    return res;
                }
            }
        }

        //469X

        fila = maxCoord.x;
        columna = maxCoord.y + 1;
        if (fila >= 0 && fila < matriz.GetLength(0) && columna >= 0 && columna < matriz.GetLength(1))
        {
            if (!int.TryParse(matriz[fila, columna].ToString(), out number))
            {
                if (matriz[fila, columna].ToString() == "*")
                {
                    var claveABuscar = (fila, columna);
                    if (diccCoord.ContainsKey(claveABuscar))
                    {
                        diccCoord[claveABuscar].Add(int.Parse(numberParam));
                    }
                    else
                    {
                        diccCoord[claveABuscar] = new List<int> { int.Parse(numberParam) };
                    }

                    res = true;
                    return res;
                }
            }
        }


        //XXXXX
        // 469
        //XXXXX
        List<int> coordToCheck = new List<int>();
        for (int i = minCoord.y - 1; i <= maxCoord.y + 1; i++)
        {
            coordToCheck.Add(i);
        }

        foreach (int coord in coordToCheck)
        {
            fila = maxCoord.x - 1;
            columna = coord;
            if (fila >= 0 && fila < matriz.GetLength(0) && columna >= 0 && columna < matriz.GetLength(1))
            {
                if (!int.TryParse(matriz[fila, columna].ToString(), out number))
                {
                    if (matriz[fila, columna].ToString() == "*")
                    {
                        var claveABuscar = (fila, columna);
                        if (diccCoord.ContainsKey(claveABuscar))
                        {
                            diccCoord[claveABuscar].Add(int.Parse(numberParam));
                        }
                        else
                        {
                            diccCoord[claveABuscar] = new List<int> { int.Parse(numberParam) };
                        }

                        res = true;
                        return res;
                    }
                }
            }


            fila = maxCoord.x + 1;
            columna = coord;
            if (fila >= 0 && fila < matriz.GetLength(0) && columna >= 0 && columna < matriz.GetLength(1))
            {
                if (!int.TryParse(matriz[fila, columna].ToString(), out number))
                {
                    if (matriz[fila, columna].ToString() == "*")
                    {
                        var claveABuscar = (fila, columna);
                        if (diccCoord.ContainsKey(claveABuscar))
                        {
                            diccCoord[claveABuscar].Add(int.Parse(numberParam));
                        }
                        else
                        {
                            diccCoord[claveABuscar] = new List<int> { int.Parse(numberParam) };
                        }

                        res = true;
                        return res;
                    }
                }
            }


        }



        return res;
    }





}

