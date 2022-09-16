using System;
using System.Globalization;

class lab1
{
    static void Main()
    {
        Console.WriteLine("Converter || Palindrom || Rabbits || CSV ?");
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Converter")
            {
                Converter();
                break;
            }
        
            if (input == "Palindrom")
            {
                Palindrom();
                break;
            }
        
            if (input == "Rabbits")
            {
                Rabbits();
                break;
            }
        
            if (input == "CSV")
            {
                CSV();
                break;
            }
        
            Console.WriteLine("--one more time--");
        }
    }

    static void CSV()
    {
        string pathCsvFile = "../../../zp.csv";
        var lines = File.ReadAllLines(pathCsvFile)[4..];
        var line = lines[0].Split(",");
        var numbersStrings = line.Skip(1).ToArray();
        List<float> numbers = new List<float>();
        foreach (var number in numbersStrings)
        {
            numbers.Add(float.Parse(number, CultureInfo.InvariantCulture.NumberFormat));
        }

        Console.WriteLine("max || min || avrg || disp ?");
        var op = Console.ReadLine();
        if (op == "max")
        {
            Console.WriteLine(max(numbers.ToArray()));
        }
        else if (op == "min")
        {
            Console.WriteLine(min(numbers.ToArray()));
        }
        else if (op == "avrg")
        {
            Console.WriteLine(average(numbers.ToArray()));
        }
        else if (op == "disp")
        {
            Console.WriteLine(disp(numbers.ToArray()));
        }
    }

    static float max(float[] array)
    {
        var max = array[0];
        foreach (var item in array)
        {
            if (item > max)
            {
                max = item;
            }
        }

        return max;
    }

    static float min(float[] array)
    {
        var min = array[0];
        foreach (var item in array)
        {
            if (item < min)
            {
                min = item;
            }
        }

        return min;
    }

    static float average(float[] array)
    {
        float result = 0;
        foreach (var item in array)
        {
            result += item;
        }

        return result / array.Length;
    }

    static double disp(float[] array)
    {
        var average = lab1.average(array);
        double gen = 0;
        foreach (var number in array)
        {
            gen += Math.Pow((number - average), 2);
        }
        var disp = gen / array.Length;
        var frac = Convert.ToDouble(array.Length) / Convert.ToDouble(array.Length - 1);
        var result = frac * disp;
        return result;
    }

    static void Palindrom()
    {
        Console.WriteLine("Word: ");
        string input = Console.ReadLine();
        int length = input.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (input[i] != input[length - i - 1])
            {
                Console.WriteLine("False");
                return;
            }
        }

        Console.WriteLine("True");
        ;
    }

    static void Converter()
    {
        Console.WriteLine("Value: ");
        int value = System.Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Your Scale(C || F || K): ");
        string scale = Console.ReadLine();
        Console.WriteLine("Target scale: ");
        string targetScale = Console.ReadLine();
        if (scale == targetScale)
        {
            Console.WriteLine(value);
        }
        else if (scale == "C" && targetScale == "F")
        {
            Console.WriteLine(value * 1.8 + 32);
        }
        else if (scale == "C" && targetScale == "K")
        {
            Console.WriteLine(value + 273);
        }
        else if (scale == "F" && targetScale == "K")
        {
            Console.WriteLine(toCelsius("F", value) + 273);
        }
        else if (scale == "K" && targetScale == "F")
        {
            Console.WriteLine(toCelsius("K", value) * 1.8 + 32);
        }
        else if (scale == "F" && targetScale == "C")
        {
            Console.WriteLine(toCelsius("F", value));
        }
        else if (scale == "K" && targetScale == "C")
        {
            Console.WriteLine(toCelsius("K", value));
        }
        else
        {
            Console.WriteLine("Error");
        }
    }

    static double toCelsius(string scale, int value)
    {
        if (scale == "F")
        {
            return value - 32 / 1.8;
        }
        else if (scale == "K")
        {
            return value - 273;
        }

        return 0;
    }

    static void Rabbits()
    {
        Console.WriteLine("Count of months: ");
        int input = System.Convert.ToInt32(Console.ReadLine());
        int result = 1;
        if (input == 1)
        {
            Console.WriteLine("1");
            return;
        }

        for (int i = 1; i < input; i++)
        {
            result *= 2;
        }

        Console.WriteLine(result);
    }
}