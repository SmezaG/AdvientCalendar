using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdvientCalendar.Days.Day5
{
    static class Day5
    {
        public static void Part1()
        {

            string filePath = @"C:\Users\Usuario\Source\Repos\SmezaG\AdvientCalendar\AdvientCalendar\Days\Day5\Day5-imput.txt";
            string imputText = File.ReadAllText(filePath);
            string[] lineas = imputText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            HashSet<string> titleSet = new HashSet<string>();
            titleSet.Add("seeds");
            titleSet.Add("seed-to-soil map");
            titleSet.Add("soil-to-fertilizer map");
            titleSet.Add("fertilizer-to-water map");
            titleSet.Add("water-to-light map");
            titleSet.Add("light-to-temperature map");
            titleSet.Add("temperature-to-humidity map");
            titleSet.Add("humidity-to-location map");

            string mapSection = "";
          
            string[] seeds = null;

            Dictionary<long, long> seedToSoil = new Dictionary<long, long>();
            Dictionary<long, long> soilToFertilizer = new Dictionary<long, long>();
            Dictionary<long, long> fertilizerToWater = new Dictionary<long, long>();
            Dictionary<long, long> waterToLight = new Dictionary<long, long>();
            Dictionary<long, long> lightToTemperature = new Dictionary<long, long>();
            Dictionary<long, long> temperatureToHumidity = new Dictionary<long, long>();
            Dictionary<long, long> humidityToLocation = new Dictionary<long, long>();

            List<long> finalList = new List<long>();

            foreach (string line in lineas)
            {
                string[] lineSplit = line.Split(":");
                if (line != "") // Omitimos las líneas en blanco
                {
                    if (titleSet.Contains(lineSplit[0]))
                    {
                        mapSection = lineSplit[0];
                        if (mapSection == "seeds")
                        {
                            string[] lineb = line.Split(":");
                            string seedsString = lineb[1].Trim().Replace("  ", " ").Replace(" ", ",");
                            seeds = seedsString.Split(",");
                        }
                    }
                    else
                    {
                        switch (mapSection)
                        {
                            
                            case("seed-to-soil map"):
                                string[] seedToSoilString = line.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                                CreaDict(seedToSoilString, ref seedToSoil);
                                break;
                            case ("soil-to-fertilizer map"):
                                string[] soilToFertilizerString = line.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                                CreaDict(soilToFertilizerString, ref soilToFertilizer);
                                break;
                            case ("fertilizer-to-water map"):
                                string[] fertilizerToWaterString = line.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                                CreaDict(fertilizerToWaterString, ref fertilizerToWater);
                                break;
                            case ("water-to-light map"):
                                string[] waterToLightString = line.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                                CreaDict(waterToLightString, ref waterToLight);
                                break;
                            case ("light-to-temperature map"):
                                string[] lightToTemperatureString = line.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                                CreaDict(lightToTemperatureString, ref lightToTemperature);
                                break;
                            case ("temperature-to-humidity map"):
                                string[] temperatureToHumidityString = line.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                                CreaDict(temperatureToHumidityString, ref temperatureToHumidity);
                                break;
                            case ("humidity-to-location map"):
                                string[] humidityToLocationString = line.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                                CreaDict(humidityToLocationString, ref humidityToLocation);
                                break;
 



                        }
                    }
                }

            }

            foreach(string seed in seeds)
            {
                long aux = 0;
                if (seedToSoil.ContainsKey(long.Parse(seed)))
                {
                    aux = seedToSoil[long.Parse(seed)];
                }
                else
                {
                    aux = long.Parse(seed);
                }

                if (soilToFertilizer.ContainsKey(aux))
                {
                    aux = soilToFertilizer[aux];
                }

                if (fertilizerToWater.ContainsKey(aux))
                {
                    aux = fertilizerToWater[aux];
                }

                if (waterToLight.ContainsKey(aux))
                {
                    aux = waterToLight[aux];
                }

                if (lightToTemperature.ContainsKey(aux))
                {
                    aux = lightToTemperature[aux];
                }

                if (temperatureToHumidity.ContainsKey(aux))
                {
                    aux = temperatureToHumidity[aux];
                }

                if (humidityToLocation.ContainsKey(aux))
                {
                    aux = humidityToLocation[aux];
                }

                finalList.Add(aux);

            }

            long menor = finalList[0];
            foreach (long valor in finalList)
            {
                if (valor < menor)
                {
                    menor = valor;
                }
            }

            Console.WriteLine(menor.ToString());
        }

        public static void CreaDict(string[] numbersToProces, ref Dictionary<long, long> dict)
        {
            long destStart = 0;
            long sourceStart = 1;
            long length = 2;

            for (int i = 0; i < long.Parse(numbersToProces[length]); i++) 
            {
                if (!dict.ContainsKey(long.Parse(numbersToProces[sourceStart]) + i ))
                {
                    dict[long.Parse(numbersToProces[sourceStart]) + i] = long.Parse(numbersToProces[destStart]) + i;
                }
            }
            

        }
    }
}
