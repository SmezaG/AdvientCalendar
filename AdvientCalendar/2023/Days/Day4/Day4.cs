using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


static class Day4
{
    public static void Part1()
    {

        string filePath = @"C:\Users\Usuario\Source\Repos\SmezaG\AdvientCalendar\AdvientCalendar\Days\Day4\Day4-imput.txt";
        string imputText = File.ReadAllText(filePath);
        string[] lineas = imputText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        List<int> WinNumberList = new List<int>();
        bool firstNumber = true;
        int answer = 0;
        int totalCupon = 0;

        foreach (string linea in lineas)
        {
            totalCupon = 0;
            firstNumber = true;
            string[] lineb = linea.Split(":");
            string[] lineaWinAndMine = lineb[1].Split("|");
            string winNumbers = lineaWinAndMine[0].Trim().Replace("  ", " ").Replace(" ",",");
            string myNumbers = lineaWinAndMine[1].Trim().Replace("  ", " ").Replace(" ", ",");

            string[] winNumbersArray = winNumbers.Split(",");
            string[] MyNumbersArray = myNumbers.Split(",");

            HashSet<string> MyNumbersHash = new HashSet<string>(MyNumbersArray);

            foreach (string winNumber in winNumbersArray)
            {
                if(MyNumbersHash.Contains(winNumber))
                {
                    if (firstNumber)
                    {
                        totalCupon = 1;
                        firstNumber = false;
                    }
                    else
                    {
                        totalCupon *= 2;
                    }
                }
            }

            answer += totalCupon;
        }

        Console.WriteLine(answer);
    }

    public static void Part2()
    {
        string filePath = @"C:\Users\Usuario\Source\Repos\SmezaG\AdvientCalendar\AdvientCalendar\Days\Day4\Day4-imput.txt";
        string imputText = File.ReadAllText(filePath);
        string[] lineas = imputText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        List<int> WinNumberList = new List<int>();
        bool firstTime = true;
        int answer = 0;
        int count = 0;
        Dictionary<string,int> dicctTimes = new Dictionary<string, int>();

        foreach (string linea in lineas)
        {
            count += 1;
            firstTime = true;
            string[] lineb = linea.Split(":");
            string key = lineb[0].Replace("Card ","").Trim();
            string[] lineaWinAndMine = lineb[1].Split("|");
            string winNumbers = lineaWinAndMine[0].Trim().Replace("  ", " ").Replace(" ", ",");
            string myNumbers = lineaWinAndMine[1].Trim().Replace("  ", " ").Replace(" ", ",");

            string[] winNumbersArray = winNumbers.Split(",");
            string[] MyNumbersArray = myNumbers.Split(",");

            HashSet<string> MyNumbersHash = new HashSet<string>(MyNumbersArray);

            
            

            CompruebaLinea(winNumbersArray, MyNumbersHash, 0, key, ref dicctTimes);
            string keyString = int.Parse(key).ToString();
            if (dicctTimes.ContainsKey(keyString) & keyString != "1")
            {
                for(int i = 0; i < dicctTimes[keyString]; i++)
                CompruebaLinea(winNumbersArray, MyNumbersHash, 0, key, ref dicctTimes);
            }

            //AñadeDict(ref dicctTimes, ref totalCupon, key);


            //answer += totalCupon;
        }


        foreach (var par in dicctTimes)
        {
            answer += par.Value;
        }
        Console.WriteLine(answer + count);

    }

    public static void AñadeDict(ref Dictionary<string, int> dicctTimes,int totalCupon, string key)
    {
        for (int i = 1; i <= totalCupon; i++)
        {
            string keyString = (int.Parse(key) + i).ToString();
            if (dicctTimes.ContainsKey(keyString))
            {
                dicctTimes[keyString] += 1;
            }
            else
            {
                dicctTimes[(keyString)] = 1;
            }
        }
    }

    public static void CompruebaLinea(string[] winNumbersArray, HashSet<string> MyNumbersHash,  int totalCupon, string key, ref Dictionary<string, int> dicctTimes)
    {

        foreach (string winNumber in winNumbersArray)
        {
            if (MyNumbersHash.Contains(winNumber))
            {
                totalCupon += 1;
            }
        }

        AñadeDict(ref dicctTimes, totalCupon, key);

    }

}
