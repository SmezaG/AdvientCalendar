using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Day7 
{
    public static void Part1()
    {
        string filePath = @"C:\Users\Usuario\Source\Repos\SmezaG\AdvientCalendar\AdvientCalendar\Days\Day7\Day7-imput.txt";
        string imputText = File.ReadAllText(filePath);
        string[] lineas = imputText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

        List<string> fiveOfaKind = new List<string>();
        List<string> fourOfaKind = new List<string>();
        List<string> fullHause = new List<string>();
        List<string> threeOfaKind = new List<string>();
        List<string> twoPair = new List<string>();
        List<string> onePair = new List<string>();
        List<string> highCard = new List<string>();
        int answer = 0;
        int count = 1;


        Dictionary<string,int> rankCards = new Dictionary<string, int>();

        rankCards["A"] = 1;
        rankCards["K"] = 2;
        rankCards["Q"] = 3;
        rankCards["J"] = 4;
        rankCards["T"] = 5;
        rankCards["9"] = 6;
        rankCards["8"] = 7;
        rankCards["7"] = 8;
        rankCards["6"] = 9;
        rankCards["5"] = 10;
        rankCards["4"] = 11;
        rankCards["3"] = 12;
        rankCards["2"] = 13;


        Dictionary<string, int> kindOfHand = null;



        string puntuacion = "";

        foreach(string linea in lineas)
        {
            string[] lineSplit = linea.Split(" ");
            puntuacion = lineSplit[1];
            char[] caracteres = lineSplit[0].ToCharArray();

            kindOfHand = new Dictionary<string, int>();

            foreach (char c in caracteres)
            {

                string aux = c.ToString();

                if (kindOfHand.ContainsKey(aux))
                {
                    kindOfHand[aux]++;
                }
                else
                {
                    kindOfHand[aux] = 1;
                }
            }

            int type = HandClasificator(kindOfHand);
            switch (type)
            {
                case (1):
                    fiveOfaKind.Add(linea);
                    break;
                case (2):
                    fourOfaKind.Add(linea);
                    break;
                case (3):
                    fullHause.Add(linea);
                    break;
                case (4):
                    threeOfaKind.Add(linea);
                    break;
                case (5):
                    twoPair.Add(linea);
                    break;
                case (6):
                    onePair.Add(linea);
                    break;
                case (7):
                    highCard.Add(linea);
                    break;
            }

        }

        fiveOfaKind.Sort((a, b) => OrdenatioRule(a, b, rankCards));
        fourOfaKind.Sort((a, b) => OrdenatioRule(a, b, rankCards));
        fullHause.Sort((a, b) => OrdenatioRule(a, b, rankCards));
        threeOfaKind.Sort((a, b) => OrdenatioRule(a, b, rankCards));
        twoPair.Sort((a, b) => OrdenatioRule(a, b, rankCards));
        onePair.Sort((a, b) => OrdenatioRule(a, b, rankCards));
        highCard.Sort((a, b) => OrdenatioRule(a, b, rankCards));

        foreach(string line in highCard)
        {
            string[] lineSplit = line.Split(" ");
            puntuacion = lineSplit[1];
            answer += (int.Parse(puntuacion) * count);
            count++;
        }

        foreach (string line in onePair)
        {
            string[] lineSplit = line.Split(" ");
            puntuacion = lineSplit[1];
            answer += (int.Parse(puntuacion) * count);
            count++;
        }

        foreach (string line in twoPair)
        {
            string[] lineSplit = line.Split(" ");
            puntuacion = lineSplit[1];
            answer += (int.Parse(puntuacion) * count);
            count++;
        }

        foreach (string line in threeOfaKind)
        {
            string[] lineSplit = line.Split(" ");
            puntuacion = lineSplit[1];
            answer += (int.Parse(puntuacion) * count);
            count++;
        }

        foreach (string line in fullHause)
        {
            string[] lineSplit = line.Split(" ");
            puntuacion = lineSplit[1];
            answer += (int.Parse(puntuacion) * count);
            count++;
        }

        foreach (string line in fourOfaKind)
        {
            string[] lineSplit = line.Split(" ");
            puntuacion = lineSplit[1];
            answer += (int.Parse(puntuacion) * count);
            count++;
        }
        foreach (string line in fiveOfaKind)
        {
            string[] lineSplit = line.Split(" ");
            puntuacion = lineSplit[1];
            answer += (int.Parse(puntuacion) * count);
            count++;
        }


        Console.WriteLine(answer);

    }

    public static int HandClasificator(Dictionary<string, int> kindOfHand)
    {

        switch (kindOfHand.Count)
        {
            case (1):
                return 1;
            case (2):
                if (kindOfHand.Values.First().Equals(1) | kindOfHand.Values.First().Equals(4))
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
                
            case (3):

                foreach (int value in kindOfHand.Values)
                {
                    if (value == 3)
                    {
                        return 4;
                    }
                }

                return 5;

            case (4):
                return 6;
            case (5):
                return 7;

            default:
                return 0;

        }

    }

    public static int OrdenatioRule(string cadena1, string cadena2, Dictionary<string, int> rankCards)
    {

        string[] lineSplit1 = cadena1.Split(" ");
        string puntuacion1 = lineSplit1[1];
        char[] caracteres1 = lineSplit1[0].ToCharArray();

        string[] lineSplit2 = cadena2.Split(" ");
        string puntuacion2 = lineSplit2[1];
        char[] caracteres2 = lineSplit2[0].ToCharArray();

        for (int i = 0; i < caracteres1.Length; i++)
        {
            if (caracteres1[i] != caracteres2[i])
            {
                if (rankCards[caracteres1[i].ToString()] > rankCards[caracteres2[i].ToString()])
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        return -1;
        
    }

}
