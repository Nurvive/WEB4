using System;
class HelloWorld {
  static void Main() {
      Console.WriteLine("Value: ");
      int value = System.Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Your Scale(C || F || K): ");
      string scale = Console.ReadLine();
      Console.WriteLine("Target scale: ");
      string targetScale = Console.ReadLine();
      if (scale == targetScale) {
          Console.WriteLine(value);
      }
      else if (scale == "C" && targetScale == "F") {
          Console.WriteLine(value * 1.8 + 32);
      }
      else if (scale == "C" && targetScale == "K") {
          Console.WriteLine(value + 273);
      }
      else if (scale == "F" && targetScale == "K") {
          Console.WriteLine(toCelsius("F", value) + 273);
      }
      else if (scale == "K" && targetScale == "F") {
          Console.WriteLine(toCelsius("K", value) * 1.8 + 32);
      }
      else if (scale == "F" && targetScale == "C") {
          Console.WriteLine(toCelsius("F", value));
      }
      else if (scale == "K" && targetScale == "C") {
          Console.WriteLine(toCelsius("K", value));
      }
  }
  
  static double toCelsius(string scale, int value) {
      if (scale == "F") {
          return value - 32 / 1.8;
      } else if (scale == "K") {
          return value - 273;
      }
      return 0;
  }
}