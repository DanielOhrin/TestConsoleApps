using System;

using TestConsoleApps.Menus.Hierarchy;
using TestConsoleApps.Winnables;

namespace TestConsoleApps.Menus
{
    public class WinnableMenu : IMenu
    {

        #region Run
        public IMenu? Run()
        {
            int choice;

            while (true)
            {
                PromptUserInput();
                // TODO Make PromptUserInput an interface member that is a dictionary 

                string? userInput = Console.ReadLine();

                try
                {
                    if (userInput == null)
                    {
                        throw new FormatException();
                    }

                    choice = int.Parse(userInput);
                }
                catch (FormatException)
                {
                    choice = -1;
                }

                // TODO Make this process dynamic...
                if (choice >= 1 && choice <= 2)
                {
                    break;
                }
            }

            switch (choice)
            {
                case 1:
                    new GuessTheNumber().Run();
                    return this;
                case 2:
                    break;
                default:
                    throw new Exception($"Unhandled input: {choice}");
            }

            return null;
        }

        #endregion

        #region PromptUserInput

        private void PromptUserInput()
        {
            // TODO Make a UserInputHandler class that handles everything about user inputs. 
            Console.Clear();
            Console.WriteLine("Choose a game:");
            Console.WriteLine();
            Console.WriteLine("1. Guess The Number");
            Console.WriteLine("2. Back");
            Console.Write("> ");
        }

        #endregion
    }
}
