using System;
class HelloWorld
{
  static void Main ()
  {
    Console.WriteLine("Word: ");
    string input = Console.ReadLine();
    int length = input.Length;
    for (int i = 0; i < length / 2; i++) {
	    if (input[i] != input[length - i - 1]){
	        Console.WriteLine("False");
	        return;
	    }
    }
    Console.WriteLine("True");;
  }
}