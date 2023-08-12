using System;
string welcomeMessage = "Welcome to the Math Game!";
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(welcomeMessage);
Console.ForegroundColor = ConsoleColor.Red;
for (int i = 0; i < 25; i++)
{
    Console.Write("-");
}
Console.ResetColor();

string? firstName;
Console.WriteLine();
Console.Write("What is your name? ");
firstName = Console.ReadLine();

Console.WriteLine($"Welcome {firstName} to the Math Game!");

Random random = new();
char yesNo = 'y';
char tryAgain = 'y';
char tutor = 'n';
const int MIN_NUMBER = 0;
const int MAX_NUMBER = 25;

int correctAnswers = 0;
int wrongAnswers = 0;

while (yesNo == 'y')
{
    Console.Clear();
    int firstNumber;
    int secondNumber;
    int sum;

    firstNumber = random.Next(MIN_NUMBER, MAX_NUMBER + 1);
    secondNumber = random.Next(MIN_NUMBER, MAX_NUMBER + 1);

    sum = firstNumber + secondNumber;
    while (tryAgain == 'y')
    {
        if (tutor == 'y')
        {
            for (int countSum = 0; countSum < sum;)
            {
                for (int count = 0; count < 4; count++)
                {
                    if (countSum != sum)
                    {
                        Console.Write("|");
                        countSum++;
                    }
                }
                if (countSum != sum)
                {
                    Console.Write("\\  ");
                    countSum++;
                }
            }
            Console.WriteLine();
        }

        Console.Write($"What is the sum of {firstNumber} + {secondNumber}? ");
        
        bool successful = int.TryParse(Console.ReadLine(), out int userGuess);
        while (!successful)
        {
            Console.WriteLine("Invalid input: please try again.");
            Console.Write($"What is the sum of {firstNumber} + {secondNumber}? ");
            successful = int.TryParse(Console.ReadLine(), out userGuess);
        }

        if (userGuess == sum)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Good job! That is correct. {firstNumber} + {secondNumber} = {sum}");
            for (double i = 0, frequency = 220; i < 3; i++, frequency *= 1.5)
            {
                Console.Beep((int)frequency, 250);
            }
            Console.ResetColor();
            tryAgain = 'n';
            tutor = 'n';
            correctAnswers++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"That is not correct yet. Do you want to try again? (y/n): ");
            for (double i = 0, frequency = 600; i < 3; i++, frequency *= 0.9)
            {
                Console.Beep((int)frequency, 250);
            }
            Console.ResetColor();
            tryAgain = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.Write("Do you want help from the tutor? (y/n): ");
            tutor = Console.ReadKey().KeyChar;
            Console.WriteLine();
            wrongAnswers++;
        }
    }

    Console.Write("You currently have ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{correctAnswers} right ");
    Console.ResetColor();
    Console.Write("and ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{ wrongAnswers} wrong.");
    Console.ResetColor();
    Console.Write($"Do you want to try another question? (y/n): ");
    yesNo = Console.ReadKey().KeyChar;
    Console.WriteLine();
    tryAgain = 'y';
    
}

Console.WriteLine();
Console.Write($"Thank you {firstName} for playing the game. ");
Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"You got {correctAnswers} right! ");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write($"and {wrongAnswers} wrong.");
Console.ResetColor();
Console.WriteLine();
Console.Write("Press any key to close the console: ");
Console.ReadKey();