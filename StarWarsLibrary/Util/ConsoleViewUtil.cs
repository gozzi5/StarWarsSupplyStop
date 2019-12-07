using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsLibrary.Util
{
    public static class ConsoleViewUtil
    {
        public static void WriteFullLine(string value, string color)
        {

            switch (color)
            {
                case "green":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
            }
            value = value + "\n";


            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }
    }
}
