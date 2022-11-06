namespace Valera;

public class Valera
{
    private int _health = 90;

    public int Health
    {
        get => _health;
        set
        {
            if (value < 0)
            {
                _health = 0;
            }
            else if (value > 100)
            {
                _health = 100;
            }
            else
            {
                _health = value;
            }
        }
    }

    private int _mana = 5;

    public int Mana
    {
        get => _mana;
        set
        {
            if (value < 0)
            {
                _mana = 0;
            }
            else if (value > 100)
            {
                _mana = 100;
            }
            else
            {
                _mana = value;
            }
        }
    }

    private int _mood = 6;

    public int Mood
    {
        get => _mood;
        set
        {
            if (value < -10)
            {
                _mood = -10;
            }
            else if (value > 10)
            {
                _mood = 10;
            }
            else
            {
                _mood = value;
            }
        }
    }

    private int _fatigue = 10;

    public int Fatigue
    {
        get => _fatigue;
        set
        {
            if (value < 0)
            {
                _fatigue = 0;
            }
            else if (value > 100)
            {
                _fatigue = 100;
            }
            else
            {
                _fatigue = value;
            }
        }
    }

    private int _money = 100;

    public void show()
    {
        Console.WriteLine("Health: " + _health + ", Mana: " + _mana + ", Mood: " + _mood + ", Fatigue: " + _fatigue +
                          ", Money: " +
                          _money);
    }

    public void work()
    {
        if (_mana < 50 && _fatigue < 10)
        {
            Mood -= 5;
            Mana -= 30;
            _money += 100;
            Fatigue += 70;
        }
        else
        {
            Console.WriteLine("Валера не может работать");
        }

        show();
    }

    public void watchNature()
    {
        Mood += 1;
        Mana -= 10;
        Fatigue += 10;
        show();
    }

    public void drinkWineWatchShow()
    {
        Mood -= 1;
        Mana += 30;
        Fatigue += 10;
        Health -= 5;
        _money -= 20;
        show();
    }

    public void goPub()
    {
        Mood += 1;
        Mana += 60;
        Fatigue += 40;
        Health -= 10;
        _money -= 100;
        show();
    }

    public void drinkAlcohol()
    {
        Mood += 5;
        Health -= 80;
        Mana += 90;
        Fatigue += 80;
        _money -= 150;
        show();
    }

    public void sing()
    {
        Mood += 1;
        if (Mana > 40 && Mana < 70)
        {
            _money += 50;
        }
        else
        {
            _money += 10;
        }

        Mana += 10;
        Fatigue += 20;
        show();
    }

    public void sleep()
    {
        if (Mana < 30)
        {
            Health += 90;
        }

        if (Mana > 70)
        {
            Mood -= 3;
        }

        Mana -= 50;
        Fatigue -= 70;
        show();
    }

    public string[] state()
    {
        return new[] { Health.ToString(), Mana.ToString(), Mood.ToString(), Fatigue.ToString(), _money.ToString() };
    }

    public void load(string[] save)
    {
        Health = Convert.ToInt32(save[0]);
        Mana = Convert.ToInt32(save[1]);
        Mood = Convert.ToInt32(save[2]);
        Fatigue = Convert.ToInt32(save[3]);
        _money = Convert.ToInt32(save[4]);
    }
}