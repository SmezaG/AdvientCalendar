using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


public static class Day1
{
    public static void Part1()
    {
        List<int> LineNumbers = new List<int>();
        List<int> ListaFinal = new List<int>();
        string filePath = @"C:\Users\Usuario\source\repos\AdvientCalendar\AdvientCalendar\Days\Day1\Day1-1-Imput.txt";
        string imputText = File.ReadAllText(filePath);
        string[] lineas = imputText.Split('\n');

        foreach (string linea in lineas)
        {
            LineNumbers.Clear();
            char[] caracteres = linea.ToCharArray();
            int numero;
            foreach(char caracter in caracteres)
            {
                if (int.TryParse(caracter.ToString(), out numero))
                {
                    LineNumbers.Add(numero);
                }
            }

            int primerValor = LineNumbers.FirstOrDefault();
            int ultimoValor = LineNumbers.LastOrDefault();

            int resultadoFinal = int.Parse(primerValor.ToString() + ultimoValor.ToString());
            ListaFinal.Add(resultadoFinal);

        }

        int answer = 0;
        foreach(int n in ListaFinal)
        {
            answer += n;
            Console.WriteLine(n);
        }

        Console.WriteLine(answer);

    }


    public static void Part2()
    {
        string filePath = @"C:\Users\Usuario\source\repos\AdvientCalendar\AdvientCalendar\Days\Day1\Day1-1-Imput.txt";
        string imputText = File.ReadAllText(filePath);
        List<int> LineNumbers = new List<int>();
        List<int> ListaFinal = new List<int>();
        Dictionary<string, string> validValues = new Dictionary<string, string>
        {
            { "one", "1"},
            { "two", "2"},
            { "three", "3"},
            { "four", "4"},
            { "five", "5"},
            { "six", "6"},
            { "seven", "7"},
            { "eight", "8"},
            { "nine", "9"},
        };


        string[] lineas = imputText.Split('\n');
        int numero;
        string compareString; 

        foreach (string linea in lineas)
        {
            LineNumbers.Clear();
            compareString = "";
            char[] caracteres = linea.ToCharArray();

            foreach (char caracter in caracteres)
            {
                compareString = $"{compareString}{caracter.ToString()}";
                if (int.TryParse(caracter.ToString(), out numero))
                {
                    LineNumbers.Add(numero);
                }
                else
                {
                    foreach (var kvp in validValues)
                    {
                        if (compareString.Contains(kvp.Key)){
                            LineNumbers.Add(int.Parse(kvp.Value));
                            compareString = compareString.Length > 0 ? compareString.Substring(compareString.Length - 1) : string.Empty;
                        }
                    }
                }
            }


            int primerValor = LineNumbers.FirstOrDefault();
            int ultimoValor = LineNumbers.LastOrDefault();

            int resultadoFinal = int.Parse(primerValor.ToString() + ultimoValor.ToString());
            ListaFinal.Add(resultadoFinal);

        }

        int answer = 0;
        foreach (int n in ListaFinal)
        {
            answer += n;
            Console.WriteLine(n);
        }

        Console.WriteLine(answer);

    }

}



