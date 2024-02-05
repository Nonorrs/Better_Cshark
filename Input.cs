using Better_Cshark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Better_Cshark
{
    public class Input
    {
        public static void MovePlayer(char[,] donjon)
        {
            // Position initiale du joueur
            int playerX = 6;
            int playerY = 6;

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
                if (donjon[nextPlayerY, nextPlayerX] != '#')
                {
                    // Effacer la position actuelle du joueur
                    donjon[playerY, playerX] = ' ';

                    // Mettre à jour la position du joueur
                    playerX = nextPlayerX;
                    playerY = nextPlayerY;

                    // Afficher le joueur à sa nouvelle position
                    donjon[playerY, playerX] = 'O';
                }

                // Afficher le donjon avec la nouvelle position du joueur
                Map.AfficherDonjon(donjon);

                if (playerX == 1 || playerY == 1 || playerX == 3 && playerY == 3)
                {
                    Console.WriteLine("Viens on fait la course quand tu veux");
                }
            }
        }
    }
}
