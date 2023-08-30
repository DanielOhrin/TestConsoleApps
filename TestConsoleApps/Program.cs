using System;
using System.Runtime.CompilerServices;
using TestConsoleApps.Configuration;
using TestConsoleApps.Menus;
using TestConsoleApps.Menus.Hierarchy;

namespace TestConsoleApps
{
    public class Program
    {
        #region App Startup

        public static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();

            while (true)
            {
                IMenu? menu = mainMenu.Run();

                if (menu is null)
                {
                    break;
                }

                while (menu != null)
                {
                    menu = menu.Run();

                    if (EnvironmentConfig.IsDebug)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Next menu: {menu?.ToString() ?? "null"}");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                }

                Goodbye();
            }
        }

        #endregion

        #region App Shutdown

        private static void Goodbye()
        {
            Console.Clear();
            Console.WriteLine("Goodbye.");
        }

        #endregion
    }
}
