using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



static class Day5a
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
        List<long> seedList = new List<long>();
        List<long> finalList = new List<long>();
        string[] seeds = null;
        string mapSection = "";


        List<long[]> seedToSoil = new List<long[]>();
        List<long[]> soilToFertilizer = new List<long[]>();
        List<long[]> fertilizerToWater = new List<long[]>();
        List<long[]> waterToLight = new List<long[]>();
        List<long[]> lightToTemperature = new List<long[]>();
        List<long[]> temperatureToHumidity = new List<long[]>();
        List<long[]> humidityToLocation = new List<long[]>();

        foreach (string linea in lineas)
        {
            string[] lineSplit = linea.Split(":");

            if (linea != "")// Omitimos las líneas en blanco
            {
                if (titleSet.Contains(lineSplit[0]))
                {
                    mapSection = lineSplit[0];

                    if (mapSection == "seeds")
                    {
                        CargaSeeds(ref seeds, lineSplit);
                    }

                }
                else
                {
                    long[] test = new long[3];
                    switch (mapSection)
                    {

                        case ("seed-to-soil map"):
                            string[] seedToSoilString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");

                            for (int i = 0; i < seedToSoilString.Length; i++)
                            {
                                test[i] = long.Parse(seedToSoilString[i]);
                            }
                            seedToSoil.Add(test);
                            break;
                        case ("soil-to-fertilizer map"):
                            string[] soilToFertilizerString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < soilToFertilizerString.Length; i++)
                            {
                                test[i] = long.Parse(soilToFertilizerString[i]);
                            }
                            soilToFertilizer.Add(test);
                            break;
                        case ("fertilizer-to-water map"):
                            string[] fertilizerToWaterString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < fertilizerToWaterString.Length; i++)
                            {
                                test[i] = long.Parse(fertilizerToWaterString[i]);
                            }
                            fertilizerToWater.Add(test);
                            break;
                        case ("water-to-light map"):
                            string[] waterToLightString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < waterToLightString.Length; i++)
                            {
                                test[i] = long.Parse(waterToLightString[i]);
                            }
                            waterToLight.Add(test);
                            break;
                        case ("light-to-temperature map"):
                            string[] lightToTemperatureString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < lightToTemperatureString.Length; i++)
                            {
                                test[i] = long.Parse(lightToTemperatureString[i]);
                            }
                            lightToTemperature.Add(test);
                            break;
                        case ("temperature-to-humidity map"):
                            string[] temperatureToHumidityString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < temperatureToHumidityString.Length; i++)
                            {
                                test[i] = long.Parse(temperatureToHumidityString[i]);
                            }
                            temperatureToHumidity.Add(test);
                            break;
                        case ("humidity-to-location map"):
                            string[] humidityToLocationString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < humidityToLocationString.Length; i++)
                            {
                                test[i] = long.Parse(humidityToLocationString[i]);
                            }
                            humidityToLocation.Add(test);
                            break;
                    }

                }
            }



        }

        foreach (string seed in seeds)
        {
            long aux = long.Parse(seed);
            foreach (long[] array in seedToSoil)
            {
                if (long.Parse(seed) >= array[1] & long.Parse(seed) <= array[1] + array[2])
                {
                    aux = long.Parse(seed) - array[1];
                    aux = aux + array[0];
                    break;
                }
            }

            foreach (long[] array in soilToFertilizer)
            {
                if (aux >= array[1] & aux <= array[1] + array[2])
                {
                    aux = aux - array[1];
                    aux = aux + array[0];
                    break;
                }
            }

            foreach (long[] array in fertilizerToWater)
            {
                if (aux >= array[1] & aux <= array[1] + array[2])
                {
                    aux = aux - array[1];
                    aux = aux + array[0];
                    break;
                }
            }

            foreach (long[] array in waterToLight)
            {
                if (aux >= array[1] & aux <= array[1] + array[2])
                {
                    aux = aux - array[1];
                    aux = aux + array[0];
                    break;
                }
            }

            foreach (long[] array in lightToTemperature)
            {
                if (aux >= array[1] & aux <= array[1] + array[2])
                {
                    aux = aux - array[1];
                    aux = aux + array[0];
                    break;
                }
            }

            foreach (long[] array in temperatureToHumidity)
            {
                if (aux >= array[1] & aux <= array[1] + array[2])
                {
                    aux = aux - array[1];
                    aux = aux + array[0];
                    break;
                }
            }

            foreach (long[] array in humidityToLocation)
            {
                if (aux >= array[1] & aux <= array[1] + array[2])
                {
                    aux = aux - array[1];
                    aux = aux + array[0];
                    break;
                }
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
        Console.WriteLine(menor);

    }

    public static void CargaSeeds(ref string[] seeds, string[] lineSplit)
    {
        string seedsString = lineSplit[1].Trim().Replace("  ", " ").Replace(" ", ",");
        seeds = seedsString.Split(",");
    }



    public static void Part2()
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
        List<long> seedList = new List<long>();
        List<long> finalList = new List<long>();
        string[] seeds = null;
        string mapSection = "";
        List<(long, long)> finalSeeds = new List<(long, long)>();
        bool fin = false;


        List<long[]> seedToSoil = new List<long[]>();
        List<long[]> soilToFertilizer = new List<long[]>();
        List<long[]> fertilizerToWater = new List<long[]>();
        List<long[]> waterToLight = new List<long[]>();
        List<long[]> lightToTemperature = new List<long[]>();
        List<long[]> temperatureToHumidity = new List<long[]>();
        List<long[]> humidityToLocation = new List<long[]>();

        foreach (string linea in lineas)
        {
            string[] lineSplit = linea.Split(":");

            if (linea != "")// Omitimos las líneas en blanco
            {
                if (titleSet.Contains(lineSplit[0]))
                {
                    mapSection = lineSplit[0];

                    if (mapSection == "seeds")
                    {
                        CargaSeeds2(ref seeds, lineSplit, ref finalSeeds);
                    }

                }
                else
                {
                    long[] test = new long[3];
                    switch (mapSection)
                    {

                        case ("seed-to-soil map"):
                            string[] seedToSoilString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");

                            for (int i = 0; i < seedToSoilString.Length; i++)
                            {
                                test[i] = long.Parse(seedToSoilString[i]);
                            }
                            seedToSoil.Add(test);
                            break;
                        case ("soil-to-fertilizer map"):
                            string[] soilToFertilizerString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < soilToFertilizerString.Length; i++)
                            {
                                test[i] = long.Parse(soilToFertilizerString[i]);
                            }
                            soilToFertilizer.Add(test);
                            break;
                        case ("fertilizer-to-water map"):
                            string[] fertilizerToWaterString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < fertilizerToWaterString.Length; i++)
                            {
                                test[i] = long.Parse(fertilizerToWaterString[i]);
                            }
                            fertilizerToWater.Add(test);
                            break;
                        case ("water-to-light map"):
                            string[] waterToLightString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < waterToLightString.Length; i++)
                            {
                                test[i] = long.Parse(waterToLightString[i]);
                            }
                            waterToLight.Add(test);
                            break;
                        case ("light-to-temperature map"):
                            string[] lightToTemperatureString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < lightToTemperatureString.Length; i++)
                            {
                                test[i] = long.Parse(lightToTemperatureString[i]);
                            }
                            lightToTemperature.Add(test);
                            break;
                        case ("temperature-to-humidity map"):
                            string[] temperatureToHumidityString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < temperatureToHumidityString.Length; i++)
                            {
                                test[i] = long.Parse(temperatureToHumidityString[i]);
                            }
                            temperatureToHumidity.Add(test);
                            break;
                        case ("humidity-to-location map"):
                            string[] humidityToLocationString = linea.Trim().Replace("  ", " ").Replace(" ", ",").Split(",");
                            for (int i = 0; i < humidityToLocationString.Length; i++)
                            {
                                test[i] = long.Parse(humidityToLocationString[i]);
                            }
                            humidityToLocation.Add(test);
                            break;
                    }

                }
            }



        }



        //for (int i = 0; i < 93; i++)
        long i2 = 0;
        while (true)
        {
            long aux = i2;
            foreach (long[] array in humidityToLocation)
            {
                if (i2 >= array[0] & i2 <= array[0] + array[2])
                {
                    aux = i2 - array[0];
                    aux = aux + array[1];
                    break;
                }
            }

            foreach (long[] array in temperatureToHumidity)
            {
                if (aux >= array[0] & aux <= array[0] + array[2])
                {
                    aux = aux - array[0];
                    aux = aux + array[1];
                    break;
                }
            }

            foreach (long[] array in lightToTemperature)
            {
                if (aux >= array[0] & aux <= array[0] + array[2])
                {
                    aux = aux - array[0];
                    aux = aux + array[1];
                    break;
                }
            }

            foreach (long[] array in waterToLight)
            {
                if (aux >= array[0] & aux <= array[0] + array[2])
                {
                    aux = aux - array[0];
                    aux = aux + array[1];
                    break;
                }
            }

            foreach (long[] array in fertilizerToWater)
            {
                if (aux >= array[0] & aux <= array[0] + array[2])
                {
                    aux = aux - array[0];
                    aux = aux + array[1];
                    break;
                }
            }

            foreach (long[] array in soilToFertilizer)
            {
                if (aux >= array[0] & aux <= array[0] + array[2])
                {
                    aux = aux - array[0];
                    aux = aux + array[1];
                    break;
                }
            }

            foreach (long[] array in seedToSoil)
            {
                if (aux >= array[0] & aux <= array[0] + array[2])
                {
                    aux = aux - array[0];
                    aux = aux + array[1];
                    break;
                }
            }


            foreach ((long, long) seedRange in finalSeeds)
            {
                if (aux >= seedRange.Item1 & aux <= seedRange.Item1 + seedRange.Item2)
                {
                    Console.WriteLine(i2);
                    fin = true;
                    break;
                }
            }

            if (fin)
            {
                break;
            }

            i2++;
        }



    }

    public static void CargaSeeds2(ref string[] seeds, string[] lineSplit, ref List<(long, long)> finalSeeds)
    {
        string seedsString = lineSplit[1].Trim().Replace("  ", " ").Replace(" ", ",");

        seeds = seedsString.Split(",");

        for (long i = 0; i < seeds.Length; i++)
        {
            long startSeed = long.Parse(seeds[i]);
            long endSeed = long.Parse(seeds[i + 1]);
            finalSeeds.Add((startSeed, endSeed));
            i += 1;
        }

    }
}

