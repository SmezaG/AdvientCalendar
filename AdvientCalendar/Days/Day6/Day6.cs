using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



static class Day6
{

    public static void Part1()
    {
        string filePath = @"C:\Users\Usuario\Source\Repos\SmezaG\AdvientCalendar\AdvientCalendar\Days\Day6\Day6-imput.txt";
        string imputText = File.ReadAllText(filePath);
        string[] lineas = imputText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

        List<int> times = new List<int>();
        List<int> distances = new List<int>();
        List<int> finalList = new List<int>();
        int winnersMoves = 0;
        int answer = 1;
        

        foreach (string linea in lineas)
        {
            string[] lineType = linea.Split(":");
            MatchCollection matches = Regex.Matches(lineType[1], @"\d+");
            if (lineType[0] == "Time") 
            {
                foreach (Match match in matches)
                {
                    times.Add(int.Parse(match.Value));
                }
            }
            else
            {
                foreach (Match match in matches)
                {
                    distances.Add(int.Parse(match.Value));
                }
            }

        }

        for (int i = 0; i < times.Count; i++)
        {
            if (winnersMoves > 0)
            {
                finalList.Add(winnersMoves); // Solo añado si es mayor que 0 si no me jode el resultado
            }
            winnersMoves = 0;
            for (int j = 0; j < times[i]; j++)
            {
            
                int calc = (j * (times[i] - j ));
                if(calc > distances[i])
                {
                    winnersMoves++;
                }
            }
        }

        // inseramos el último registro que es el que se nos queda al salir de bucle
        if (winnersMoves > 0)
        {
            finalList.Add(winnersMoves); // Solo añado si es mayor que 0 si no me jode el resultado
        }

        foreach (int i in finalList)
        {
            answer *= i;
        }

        Console.WriteLine(answer);

    }



    public static void Part2()
    {
        string filePath = @"C:\Users\Usuario\Source\Repos\SmezaG\AdvientCalendar\AdvientCalendar\Days\Day6\Day6-imput.txt";
        string imputText = File.ReadAllText(filePath);
        string[] lineas = imputText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

        List<long> times = new List<long>();
        List<long> distances = new List<long>();
        List<long> finalList = new List<long>();
        long winnersMoves = 0;



        foreach (string linea in lineas)
        {
            string[] lineType = linea.Split(":");
            string match = lineType[1].Replace(" ","");
            if (lineType[0] == "Time")
            {             
                    times.Add(long.Parse(match));               
            }
            else
            {             
                distances.Add(long.Parse(match));               
            }

        }

        for (int i = 0; i < times.Count; i++)
        {
            if (winnersMoves > 0)
            {
                finalList.Add(winnersMoves); // Solo añado si es mayor que 0 si no me jode el resultado
            }
            winnersMoves = 0;
            for (int j = 0; j < times[i]; j++)
            {

                long calc = (j * (times[i] - j));
                if (calc > distances[i])
                {
                    winnersMoves++;
                }
            }
        }

        Console.WriteLine(winnersMoves);

        //// inseramos el último registro que es el que se nos queda al salir de bucle
        //if (winnersMoves > 0)
        //{
        //    finalList.Add(winnersMoves); // Solo añado si es mayor que 0 si no me jode el resultado
        //}

        //foreach (int i in finalList)
        //{
        //    answer *= i;
        //}

        //Console.WriteLine(answer);

    }


}

