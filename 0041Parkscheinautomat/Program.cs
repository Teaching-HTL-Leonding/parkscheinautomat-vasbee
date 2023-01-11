//Vanessa Spiegl

Console.Clear();

float money = 0;
float totalparktime = 0, parkingtimehours = 0, parkingtimeminutes = 0;
float restcoins = 0, restcoinseuro = 0, restcoinscent = 0;
int number = 0;
string input;
float money_coins = 0;


void PrintWelcome()
{
    System.Console.WriteLine("Parkscheinautomat mit Mindestparkdauer 30 Min und Höchstparkdauer 1:30 Stunden");
    System.Console.WriteLine("Tarif pro Stunde: 1 Euro");
    System.Console.WriteLine("Zulässige Münzen: 5 (Cents), 10 (Cents), 20 (Cents), 50 (Cents), 1 (Euro), 2 (Euro)");
    System.Console.WriteLine("Parkschein drucken mit d oder D");
    System.Console.WriteLine();
}


void EnterCoins()
{
    do
    {
        number = 0;
        System.Console.Write("Ihre Eingabe: ");
        input = Console.ReadLine()!;

        switch (input)
        {
            case "2": money += 2f; { money_coins = 2f; } break;
            case "1": money += 1f; { money_coins = 1f; } break;
            case "50": money += 0.5f; { money_coins = 0.5f; } break;
            case "20": money += 0.2f; { money_coins = 0.2f; } break;
            case "10": money += 0.1f; { money_coins = 0.1f; } break;
            case "5": money += 0.05f; { money_coins = 0.05f; } break;
            case "d": if (money < 0.5f) {float money_coins2 = money * 100; System.Console.WriteLine($"Mindesteinwurf 50 Cent, bisher haben Sie {money_coins2} Cent eingeworfen");} { money_coins = 0; } break;
            case "D": if (money < 0.5f) {float money_coins2 = money * 100; System.Console.WriteLine($"Mindesteinwurf 50 Cent, bisher haben Sie {money_coins2} Cent eingeworfen");} { money_coins = 0; } break;
            default: System.Console.WriteLine("Falsche Eingabe"); number = 1; break;
        }
        totalparktime = parkingtimehours * 60 + parkingtimeminutes;
    }
    while (number == 1);
}


void AddParkingTime()
{
    if (money_coins == 2) { totalparktime += 120; }
    else if (money_coins == 1) { totalparktime += 60; }
    else if (money_coins == 0.5f) { totalparktime += 30; }
    else if (money_coins == 0.2f) { totalparktime += 12; }
    else if (money_coins == 0.1f) { totalparktime += 6; }
    else if (money_coins == 0.05f) { totalparktime += 3; }
}


void ConvertTotalParkTimeInHoursAndMinutes()
{
    if (totalparktime >= 60)
    {
        parkingtimehours = (float)Math.Floor(totalparktime / 60);
        parkingtimeminutes = totalparktime - parkingtimehours * 60;
    }
    else
    {
        parkingtimeminutes = totalparktime;
    }
}


void PrintEndParkTime()
{
    System.Console.WriteLine();
    if (totalparktime >= 90)
    {
        System.Console.WriteLine("Sie dürfen 1:30 Stunden parken");
    }
    else
    {
        System.Console.WriteLine($"Sie dürfen {parkingtimehours}:{parkingtimeminutes} Stunden parken");
    }
}


void PrintParkingTime()
{
    System.Console.WriteLine($"Parkzeit bisher: {parkingtimehours}:{parkingtimeminutes}");
}


void PrintDonation()
{
    totalparktime -= 90;
    restcoins = totalparktime / 60f;

    {
        restcoinseuro = (float)Math.Floor(restcoins);
        restcoinscent = restcoins % 1;
        restcoinscent = restcoinscent * 100;
        restcoinscent = (float)Math.Floor(restcoinscent);
    }

    if (restcoinseuro > 0 && restcoinscent > 0)
    {
        System.Console.WriteLine($"Danke für Ihre Spende von {restcoinseuro} Euro {restcoinscent} Cent");
    }
    else if (restcoinseuro > 0)
    {
        System.Console.WriteLine($"Danke für Ihre Spende von {restcoinseuro} Euro ");
    }
    else
    {
    System.Console.WriteLine($"Danke für Ihre Spende von {restcoinscent} Cent");
    }
}


PrintWelcome();
do
{
    ConvertTotalParkTimeInHoursAndMinutes();
    PrintParkingTime();
    EnterCoins();
    AddParkingTime();
}
while (input != "d" && input != "D" && totalparktime < 90);

if (totalparktime < 30)
{
    do
    {
        ConvertTotalParkTimeInHoursAndMinutes();
        PrintParkingTime();
        EnterCoins();
        AddParkingTime();
    }
    while (input != "d" && input != "D" && totalparktime < 30);

    do
    {
        ConvertTotalParkTimeInHoursAndMinutes();
        PrintParkingTime();
        EnterCoins();
        AddParkingTime();
    }
    while (input != "d" && input != "D" && totalparktime < 90);
}

PrintEndParkTime();

if (totalparktime > 90)
{
    PrintDonation();
}
