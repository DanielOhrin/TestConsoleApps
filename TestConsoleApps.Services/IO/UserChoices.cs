using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TestConsoleApps.Services.IO
{
    public class UserChoices<T1, T2>
    {

        #region Protected Fields

        protected List<string> PromptList;
        protected TypeConverter Converter;
        protected Dictionary<T1, T2> Choices;

        #endregion


        #region Constructor

        /// <summary>
        /// Creates a new instance of the UserChoices handler
        /// </summary>
        /// <param name="promptList">Lines of text to display when prompting user input</param>
        /// <param name="choices">Keys/Values that will be used to match the user's choice</param>
        public UserChoices(List<string> promptList, Dictionary<T1, T2> choices)
        {
            PromptList = promptList;
            Choices = choices;
            Converter = TypeDescriptor.GetConverter(typeof(T1));
        }
        #endregion


        #region Public Methods

        /// <summary>
        /// Prompts, validates, and 
        /// </summary>
        /// <returns>Value of the choice from the Choices dictionary.</returns>
        public T2 GetChoice()
        {
            // TODO Make errors somewhat dynamic
            // TODO Consider making user choice display automatically. Would likely make a class for the Key in the dictionary that would have options, such as display/don't display
            List<string> errors = new List<string>();

            while (true)
            {
                Console.Clear();

                //! Display errors from previous loop iteration
                if (errors.Count != 0)
                {
                    Console.WriteLine("ERRORS:");

                    foreach (string error in errors)
                    {
                        if (!string.IsNullOrWhiteSpace(error))
                        {
                            Console.WriteLine($"\t{error}");
                        }
                    }

                    errors = new List<string>();
                }

                //! Separate errors from prompt
                Console.WriteLine();

                //! Prompt user for input
                Prompt();

                //! Display custom cursor
                Console.WriteLine();
                Console.Write("> ");

                bool isValidInput = TryParse(Console.ReadLine(), out var choice);

                if (!isValidInput)
                {
                    //! Create type error
                    errors.Add($"Invalid message type received. Expected: {typeof(T1)}");
                    continue;
                }

                if (!Choices.ContainsKey(choice))
                {
                    errors.Add($"Invalid choice received. Received: {choice}");
                    continue;
                }

                return Choices[choice];
            }
        }

        #endregion


        #region Protected Methods

        /// <summary>
        /// Displays each line in the <see cref="PromptList"/>
        /// </summary>
        protected void Prompt()
        {
            foreach (string line in PromptList)
            {
                Console.WriteLine(line);
            }
        }

        #endregion


        #region Private Methods

#nullable disable
        private bool TryParse(string choice, out T1 value)
        {
            if (Converter.CanConvertTo(typeof(T1)) && Converter.CanConvertFrom(typeof(string)))
            {
                value = (T1)Converter.ConvertFromString(choice);
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }
#nullable enable

        #endregion

        // TODO Get User Choice!
        // TODO Officially make a ticket for abstracting UserChoices... and then work on making other tickets afterwards.
    }
}
