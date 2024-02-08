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
            public void MovePlayer(int[,] donjon, Inventaire inventory, PNJ pnj1)
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
                    else if (key.Key == ConsoleKey.P)
                    {
                        inventory.DisplayInventory();
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

                    if (playerX == 1 || playerY == 1)
                    {
                        Console.WriteLine("Viens on fait la course quand tu veux");
                    }

                    if (playerX ==3  && playerY == 3)
                    {
                        pnj1.Talk(inventory);
                    }
                }
            }

            public static void BattleInput()
            {
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

                        }
                }

            }
        }

