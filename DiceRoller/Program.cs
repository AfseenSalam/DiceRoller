// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;

Console.WriteLine("==============");
Console.WriteLine("DICE Roller");
Console.WriteLine("==============");
Console.WriteLine("Please enter the name:");
string? name = Console.ReadLine();
bool IsValid = true;
int userChoice = 0;
int index = 1;
while (IsValid)
{
    Console.WriteLine($"{name} Enter the number of sides for a pair of dice(minimum>=2):");
    string input = Console.ReadLine();
    try
    {
        userChoice = int.Parse(input);
        if (userChoice >= 2)
        {
            Console.WriteLine($"{name} you entered {userChoice}");
            break;
        }
        else
        {
            Console.WriteLine("Range is above 2.");
            continue;

        }

    }
    catch (Exception e)
    {
        Console.WriteLine("Invalid input");
        continue;
    }
}
while (IsValid) {
    int roll1 = GenerateRandomNumber(userChoice);
    int roll2 = GenerateRandomNumber(userChoice);
    int total = 0;
    total = roll1 + roll2;
    Console.WriteLine($"Roll:{index}");
    Console.WriteLine($"You rolled a {roll1} and {roll2}({total}total)");
    
    if (userChoice == 6)
    {
        Console.WriteLine(Sixsideddice(roll1, roll2));
        Console.WriteLine(ForTotal(roll1, roll2));
       
        
    }
    else if(userChoice== 4)
    {
        Console.WriteLine(Foursideddice(roll1, roll2));
        Console.WriteLine(ForFourSidedTotal(roll1, roll2));
       
    }
   
        while (IsValid)
        {
            Console.WriteLine("Roll Again? y/n:");
            string? again = Console.ReadLine();
            if (again == "n")
            {
                Console.WriteLine("Thank You for playing!");
                IsValid = false;
                break;
            }
            else if (again == "y")
            {
                index++;
                break;
            }
            else
            {
                Console.WriteLine("Invalid");
                IsValid = true;
            }
        }
}

static int GenerateRandomNumber(int userChoice)
{
    Random random = new Random();
    int roll = random.Next(1, userChoice + 1);
    return roll;
}

static string Sixsideddice(int roll1,int roll2)
{
    if (roll1 == 1 && roll2 == 1)
    {
        return "Snake Eyes";

    }
    else if (roll1 == 1 && roll2 == 2)
    {
        return "Ace Deuce" ;      
    }
    else if (roll1 == 6 && roll2 == 6)
    {
        return "Box Cars";
    }
    else
    {
        return "";
    }
    
}
static string ForTotal (int roll1,int roll2)
{
    int total = roll1 + roll2;

    if (total == 2 || total == 3 || total == 12)
    {
        return "Craps!";
    }
    if (total ==7 || total == 11)
    {
        return "Win!";
    }
    return "";
}

static string Foursideddice(int roll1,int roll2)
{
    if (roll1 == 1 && roll2 == 1)
    {
        return "Special win condition.";

    }
    else if (roll1 == 4 && roll2 == 4)
    {
        return "High value special win.";
    }
    else
    {
        return "";
    }
}
static string ForFourSidedTotal(int roll1, int roll2)
{
    int total = roll1 + roll2;

    if (total == 2)
    {
        return "Could be considered a losing condition.";
    }
    if (total == 7 || total == 8)
    {
        return "Win!";
    }
    return "";
}