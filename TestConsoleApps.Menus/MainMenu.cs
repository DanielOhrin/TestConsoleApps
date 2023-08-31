using System;
using System.Collections.Generic;
using System.ComponentModel;

using TestConsoleApps.Menus.Hierarchy;

namespace TestConsoleApps.Menus
{
    public class MainMenu : IMenu
    {

        #region Run

        public IMenu? Run()
        {
            int choice;

            while (true)
            {
                PromptUserInput();

                try
                {
                    string? userInput = Console.ReadLine();

                    if (userInput == null)
                    {
                        throw new FormatException();
                    }
                    // TODO: Allow switching from DEV to PROD
                    choice = int.Parse(userInput);

                    if (choice >= 1 && choice <= 2)
                    {
                        break;
                    }
                }
                catch (Exception ex) when (ex is FormatException)
                {

                }
            }

            // TODO: Switch this to a Dictionary 

            switch (choice)
            {
                case 1:
                    return new WinnableMenu();
                case 4:
                    return null;
                default: throw new Exception($"Unhandled choice: {choice}");
            }
        }

        #endregion

        #region PromptUserInput

        /// <summary>
        /// Displays the screen that requests user input. Does not collect the input.
        /// </summary>
        private void PromptUserInput()
        {
            Console.Clear();
            Console.WriteLine("Welcome to *Test Apps*");
            Console.WriteLine();
            Console.WriteLine("Select a category:");
            // TODO: Make the categories display dynamically. Perhaps a class should be used for this?
            Console.WriteLine("1. Games");
            Console.WriteLine("2. Exit");
            Console.WriteLine();
            Console.Write("> ");
        }

        #endregion
    }
}
