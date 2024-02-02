using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Better_Cshark
{
    class Input
    {
        public static void InputController()
        {
            Console.WriteLine("Appuyez sur une touche et sur E pour quitter.");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    HandleKeyPress(key);

                    if (key.Key == ConsoleKey.E)
                    {
                        Console.WriteLine("Cette action aura des conséquences...");
                        break;
                    }
                }
            }
        }

        static void HandleKeyPress(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key) 
            {
                case ConsoleKey.Z:
                case ConsoleKey.UpArrow:
                    Console.WriteLine("Avancer");
                    //Code pour bouger
                    break;
                case ConsoleKey.Q:
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("Aller à gauche");
                    //Code pour bouger
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    Console.WriteLine("Reculer");
                    //Code pour bouger
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    Console.WriteLine("Aller à droite");
                    //Code pour bouger
                    break;

                default:
                    Console.WriteLine("Touche non gérée: " + keyInfo.Key);
                    break;
            }
        }
    }
}
