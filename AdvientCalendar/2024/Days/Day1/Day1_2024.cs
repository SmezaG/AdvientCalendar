using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


public static class Day1_2024
{
    public static void Part1()
    {
        List<int> LineNumbers = new List<int>();
        List<int> ListaFinal = new List<int>();
        string filePath = @"C:\Users\Usuario\Source\Repos\SmezaG\AdvientCalendar\AdvientCalendar\2024\Days\Day1\Day1-1-Imput_2024.txt";
        string imputText = File.ReadAllText(filePath);
        string[] lineas = imputText.Split('\n');

        List<int> firstColumn = new List<int>();
        List<int> secondColumn = new List<int>();

        foreach (string linea in lineas)
        {

            string[] numbers = linea.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            firstColumn.Add(int.Parse(numbers[0]));
            secondColumn.Add(int.Parse(numbers[1]));

        }

            firstColumn.Sort();
            secondColumn.Sort();

            int totalSuma = 0;
            int suma = 0;
            for(int i = 0; i <= firstColumn.Count - 1; i++)
            {
            suma = int.Parse(secondColumn[i].ToString()) - int.Parse(firstColumn[i].ToString());
            if (suma < 0) {
                suma = suma * -1;
            }
            totalSuma += suma;
            }

            Console.WriteLine(totalSuma);

    }



}







