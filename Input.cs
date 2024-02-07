using Better_Cshark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Better_Cshark
{
<<<<<<< HEAD
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
=======
    public class Input
    {
        public static void MovePlayer(int[,] donjon)
        {
            // Position initiale du joueur
            int playerX = 6;
            int playerY = 6;
>>>>>>> 9cb92d4bdd1d71cbbfb5160b15ee87c7d0a43589

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();

                // Vérifier si le joueur peut se déplacer dans la direction demandée
                int nextPlayerX = playerX;
                int nextPlayerY = playerY;

                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.Z)
                {
                    nextPlayerY--;
                }
                else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                {
                    nextPlayerY++;
                }
                else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.Q)
                {
                    nextPlayerX--;
                }
                else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                {
                    nextPlayerX++;
                }
                else if (key.Key == ConsoleKey.E)
                {
                    break;
                }

                // Vérifier si la prochaine position est valide (pas un mur)
                if (donjon[nextPlayerY, nextPlayerX] != 1)
                {
                    // Effacer la position actuelle du joueur
                    donjon[playerY, playerX] = ' ';

                    // Mettre à jour la position du joueur
                    playerX = nextPlayerX;
                    playerY = nextPlayerY;

                }

                // Afficher le donjon avec la nouvelle position du joueur
                Map.AfficherMap1(playerY, playerX);

                if (playerX == 1 || playerY == 1 || playerX == 3 && playerY == 3)
                {
                    Console.WriteLine("Viens on fait la course quand tu veux");
                }
            }
        }

        public static void BattleInput()
        {
<<<<<<< HEAD
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
=======
            while (true)
            {

                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Tu fais quoi wesh ma poule");

                if (key.Key == ConsoleKey.NumPad1) // Attaquer agresivement
                {
                    Console.WriteLine("1 - Attaquons agressivement.");
                }
                else if (key.Key == ConsoleKey.NumPad2) // Inventaire
                {
                    Console.WriteLine("2 - Tu veux utiliser un objet agresivement ? Ah sale noob sans objet ici !");
                }
                else if (key.Key == ConsoleKey.NumPad3) // Changer de savun reference
                {
                    Console.WriteLine("3 - Qu'elle ref meme veux tu pour la horde !");
                }
                else if (key.Key == ConsoleKey.NumPad4) // Fuir
                {
                    Console.WriteLine("4 - Doucement D'accord ! NIGERUNDAYO !!!!");
                }
>>>>>>> 9cb92d4bdd1d71cbbfb5160b15ee87c7d0a43589
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
