using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DelegateDictionaryPattern_Menu
{
    class Program
    {
        public enum MenuOption
        {
            None,
            DisplayName,
            DisplayAddress,
            Quit
        }

        static void Main(string[] args)
        {

            Dictionary<MenuOption, Action> menuActionMap = new Dictionary<MenuOption, Action>();

            menuActionMap.Add(MenuOption.DisplayName, DisplayAddress);
            menuActionMap.Add(MenuOption.DisplayAddress, DisplayName);
            menuActionMap.Add(MenuOption.Quit, Quit);



        }

        private static void Quit()
        {
            Environment.Exit(1);
        }

        private static void DisplayName()
        {
            Console.WriteLine();
            Console.WriteLine("John E Velis");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private static void DisplayAddress()
        {
            Console.WriteLine();
            Console.WriteLine("6625 Echo Valley Road");
            Console.WriteLine("Empire, MI 49630");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
