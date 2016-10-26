using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo_DelegateDictionaryPattern_Menu
{
    class Program
    {
        public enum MenuOption
        {
            None,
            DisplayName = 1,
            DisplayAddress,
            Quit
        }

        static void Main(string[] args)
        {
            Dictionary<MenuOption, Action> menuActionMap = new Dictionary<MenuOption, Action>();

            menuActionMap.Add(MenuOption.DisplayName, DisplayAddress);
            menuActionMap.Add(MenuOption.DisplayAddress, DisplayName);
            menuActionMap.Add(MenuOption.Quit, Quit);

            MenuOption menuChoice = MenuOption.None;

            menuChoice = DisplayGetMenuChoice();

            if (menuActionMap.ContainsKey(menuChoice))
                menuActionMap[menuChoice]();
            else
                Console.WriteLine("Invalid Choice");

        }

        private static MenuOption DisplayGetMenuChoice()
        {
            MenuOption menuChoice = MenuOption.None;
            int menuChoiceNumber = 1;

            DisplayHeader("Main Menu");

            foreach (MenuOption menuItem in Enum.GetValues(typeof(MenuOption)))
            {
                if (menuItem != MenuOption.None)
                {
                    Console.WriteLine((int)menuItem + ") " + ToLabelFormat(menuItem.ToString()));
                    menuChoiceNumber++;
                }
            }

            Console.Write("Menu Choice: ");

            menuChoice = (MenuOption)int.Parse(Console.ReadLine());

            DisplayContinuePrompt();

            return menuChoice;


        }

        private static void Quit()
        {
            Environment.Exit(1);
        }

        private static void DisplayName()
        {
            DisplayHeader("Name");

            Console.WriteLine();
            Console.WriteLine("John E Velis");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");

            DisplayContinuePrompt();
        }

        private static void DisplayAddress()
        {
            DisplayHeader("Address");

            Console.WriteLine();
            Console.WriteLine("6625 Echo Valley Road");
            Console.WriteLine("Empire, MI 49630");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");

            DisplayContinuePrompt();
        }

        private static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(headerText);
            Console.WriteLine();
        }

        /// <summary>
        /// convert camel-case to all upper case and spaces
        /// reference URL - http://stackoverflow.com/questions/15458257/how-to-have-enum-values-with-spaces
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String ToLabelFormat(String s)
        {
            var newStr = Regex.Replace(s, "(?<=[A-Z])(?=[A-Z][a-z])", " ");
            newStr = Regex.Replace(newStr, "(?<=[^A-Z])(?=[A-Z])", " ");

            return newStr;
        }
    }
}
