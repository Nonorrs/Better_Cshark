using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Better_Cshark
{
    class Program
    {
        static void onsenfou(string[] args)
        {
            Input.InputController(5, 5); // Appel de la méthode de contrôle d'entrée
        }
    }

    class Input
    {
        // Déclaration des positions initiales du personnage
        static int posX;
        static int posY;

        public static void InputController(int startX, int startY)
        {
            posX = startX; // Définir la position initiale X du joueur
            posY = startY; // Définir la position initiale Y du joueur

            // Dessine le personnage à sa position initiale
            Console.SetCursorPosition(posX, posY);
            Console.Write("O");
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
                    MoveCharacter(0, -1);
                    break;
                case ConsoleKey.Q:
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("Aller à gauche");
                    MoveCharacter(-1, 0); 
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    Console.WriteLine("Reculer");
                    MoveCharacter(0, 1); 
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    Console.WriteLine("Aller à droite");
                    MoveCharacter(1, 0);
                    break;
                default:
                    Console.WriteLine("Touche non gérée: " + keyInfo.Key);
                    break;
            }
        }

        static void MoveCharacter(int deltaX, int deltaY)
        {
            // Efface le personnage de sa position actuelle
            Console.SetCursorPosition(posX, posY);
            Console.Write(" ");

            // Calcule la nouvelle position du personnage
            int newPosX = posX + deltaX;
            int newPosY = posY + deltaY;

            // Vérifie les limites de l'écran
            if (newPosX >= 0 && newPosX < Console.WindowWidth && newPosY >= 0 && newPosY < Console.WindowHeight)
            {
                posX = newPosX;
                posY = newPosY;
            }

            // Dessine le personnage à sa nouvelle position
            Console.SetCursorPosition(posX, posY);
            Console.Write("O");
        }
    }
}
