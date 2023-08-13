/*
    Description: This program is a math game that asks the user to add two random numbers together.
    The user can choose to have the tutor help them by showing them the sum of the two numbers.
    The user can also choose to play again or quit the game.

    Inputs: The user's name, the user's guess, and the user's choice to play again or not.

    Outputs: The user's name, the user's score, and the correct answer to the math problem.

    Variables: firstName, yesNo, tryAgain, tutor, MIN_NUMBER, MAX_NUMBER, correctAnswers, 
               wrongAnswers, firstNumber, secondNumber, sum, userGuess, successful, frequency, 
               i, countSum, count, welcomeMessage

    Constants: MIN_NUMBER, MAX_NUMBER

    Summarized Algorithm: 
        1. Ask the user for their name.
        2. Welcome the user to the game.
        3. Ask the user if they want to play the game.
        4. Generate two random numbers between 0 and 25.
        5. Add the two random numbers together.
        6. Ask the user for their guess.
        7. If the user's guess is correct, congratulate them and add 1 to their score.
        8. If the user's guess is incorrect, ask them if they want to try again.
        9. If the user wants to try again, ask them if they want help from the tutor.
        10. If the user wants help from the tutor, show them the sum of the two random numbers.
        11. If the user does not want help from the tutor, ask them for their guess again.
        12. If the user does not want to try again, ask them if they want to play again.
        13. If the user wants to play again, generate two new random numbers.
        14. If the user does not want to play again, thank them for playing the game and show them their score.
        15. End the program.
*/

List<TimeSpan> durations = new();
string welcomeMessage = "Welcome to the Math Game!";
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(welcomeMessage);
Console.ForegroundColor = ConsoleColor.Red;

// A for loop that prints out a line of dashes the same length as the welcome message.
for (int i = 0; i < welcomeMessage.Length; i++)
{
    Console.Write("-");
}

// Reset the console color to the default color.
Console.ResetColor();

// Ask the user for their name.
// The ? after the data type means that the variable can be null.
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
    DateTime startTime = DateTime.Now;

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
            TimeSpan timeSpan = DateTime.Now - startTime;
            durations.Add(timeSpan);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Good job! That is correct. {firstNumber} + {secondNumber} = {sum}");
            Console.WriteLine($"You took {timeSpan.TotalSeconds} seconds to answer the question.");
            // This method is not supported on Linux.
            PlaySuccessTone();
            
            // Play a system alert tone.
            // Console.Write("\a");
            
            Console.ResetColor();
            tryAgain = 'n';
            tutor = 'n';
            correctAnswers++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"That is not correct yet. Do you want to try again? (y/n): ");

            // This method is not supported on Linux.
            PlayErrorTone();

            // Play a system alert tone.
            Console.Write("\a");

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
Console.WriteLine(durations.Count > 0 ? $" Your average time was {durations.Average(time => time.TotalSeconds):F2} seconds." : "");
Console.WriteLine();
Console.Write("Press any key to close the console: ");
Console.ReadKey();

void PlayErrorTone()
{
    if (OperatingSystem.IsWindows())
    {
        for (double i = 0, frequency = 600; i < 3; i++, frequency *= 0.9)
        {
            // This method is not supported on Linux.
            Console.Beep((int)frequency, 250);
        }
    }
    
    else
    {
        Console.Write("\a");
    }
}

void PlaySuccessTone()
{
    if (OperatingSystem.IsWindows())
    {
        for (double i = 0, frequency = 220; i < 3; i++, frequency *= 1.5)
        {
            // This method is not supported on Linux.
            Console.Beep((int)frequency, 250);
        }
    }

    else
    {
        Console.Write("\a");
    }
}

