using System.Text;

namespace Lab2;

class Lab2
{
    static void save(Valera.Valera valera)
    {
        File.WriteAllLines(@"C:\Users\jiimb\RiderProjects\WEB4\Valera\save.txt", valera.state(), Encoding.UTF8);
    }

    static void load(Valera.Valera valera)
    {
        var save = File.ReadAllLines(@"C:\Users\jiimb\RiderProjects\WEB4\Valera\save.txt", Encoding.UTF8);
        valera.load(save);
    }

        static void Main()
    {
        Valera.Valera marginal = new Valera.Valera();
        Console.WriteLine(
            "end: -1, show: 1, work: 2, watchNature: 3, drinkWineWatchShow: 4, goPub: 5, drinkAlcohol: 6, sing: 7, sleep: 8, save: s, load: l");
        marginal.show();
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "-1")
            {
                break;
            }

            if (input == "1")
            {
                marginal.show();
            }
            else if (input == "2")
            {
                marginal.work();
            }
            else if (input == "3")
            {
                marginal.watchNature();
            }
            else if (input == "4")
            {
                marginal.drinkWineWatchShow();
            }
            else if (input == "5")
            {
                marginal.goPub();
            }
            else if (input == "6")
            {
                marginal.drinkAlcohol();
            }
            else if (input == "7")
            {
                marginal.sing();
            }
            else if (input == "8")
            {
                marginal.sleep();
            }
            else if (input == "s")
            {
                save(marginal);
            }
            else if(input == "l")
            {
                load(marginal);
                marginal.show();
            }
        }
    }
}