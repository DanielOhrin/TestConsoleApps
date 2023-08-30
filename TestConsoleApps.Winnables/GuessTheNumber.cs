using System;
using TestConsoleApps.Configuration;
using TestConsoleApps.Winnables.Hierarchy;

namespace TestConsoleApps.Winnables
{
    public class GuessTheNumber : Winnable, IRepeatable
    {
        // TODO implement multiple guess functionality
        // TODO Add logic for displaying average guesses
        // TODO make tic-tac-toe game
        public int Min { get; set; } = 1;
        public int Max { get; set; } = 100;
        public int Guesses { get; set; } = 1;

        #region Winnable Logic

        public override void Run()
        {
            // TODO make class to store statistics for easy reference
            int wins = 0;
            int losses = 0;
            bool playAgain = true;

            while (playAgain)
            {
                if (Play())
                {
                    wins++;
                }
                else
                {
                    losses++;
                }

                //! Play Again Request
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Play Again? (Y/N): ");
                    Console.Write("> ");

                    string userInput = Console.ReadLine()?.ToLower() ?? "";

                    if (userInput == "y" || userInput == "yes")
                    {
                        break;
                    }

                    if (userInput == "n" || userInput == "no")
                    {
                        playAgain = false;
                        break;
                    }
                }
            }
            // TODO Implement higher/lower after multiple guesses are added.
            // TODO Implement cheat modes for development
            Console.Clear();
            Console.WriteLine($"Wins: {wins} ({((decimal)wins / (wins + losses) * 100M).ToString("0.00")}%)");
            Console.WriteLine($"Losses: {losses} ({((decimal)losses / (wins + losses) * 100M).ToString("0.00")}%)");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            // TODO Look at this design again. Possibly change definition of Winnable to just be public bool Run();
        }

        protected override bool Play()
        {
            int answer = new Random().Next(Min, Max + 1);
            int? guess = null;
            string errorMessage = string.Empty;

            while (guess == null)
            {
                Console.Clear();
                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    Console.WriteLine(errorMessage);
                }
                // TODO: Add this into settings
                Console.WriteLine("Guess the number (1-100)");
                // TODO: Make this a global method for requesting user input. Make it take in a generic that will validate a return type!
                Console.Write("> ");

                try
                {
                    string userInput = Console.ReadLine() ?? "";

                    //! If environment is Development and user types "bypass," they win automatically
                    guess = EnvironmentConfig.Environment == Configuration.Environment.Development && userInput.ToLower() == "bypass" ? answer : int.Parse(userInput);

                    if (guess < Min || guess > Max)
                    {
                        throw new ArgumentOutOfRangeException($"Guess must be between {Min}-{Max}");
                    }

                    continue;
                }
                catch (Exception ex) when (ex is FormatException || ex is ArgumentOutOfRangeException)
                {
                    guess = null;
                    errorMessage = $"Guess must be a whole number between {Min}-{Max}";
                }
            }

            Console.Clear();
            Console.WriteLine($"Answer: {answer}");
            Console.WriteLine($"Guess: {guess}");
            Console.WriteLine();
            Console.WriteLine("You " + (guess == answer ? "WIN!" : "LOSE."));

            return answer == guess;
        }

        protected override void Settings()
        {
            // TODO THIS
            throw new NotImplementedException();
        }

        #endregion

        #region IRepeatable Logic
        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
