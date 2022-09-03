using System;
class HelloWorld
{
  static void Main ()
  {
    Console.WriteLine("Count of months: ");
    int input = System.Convert.ToInt32(Console.ReadLine());
    int result = 1;
    if (input == 1) {
        Console.WriteLine("1");
        return;
    }
    for (int i = 1; i < input; i++) {
        result *= 2;
    }
    Console.WriteLine(result);
  }
}