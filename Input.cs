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
            public void inputPlayer(ConsoleKeyInfo _key, Player player, int[,] map)
            {
            // Vérifier si le joueur peut se déplacer dans la direction demandée
            int nextPlayerX = player.playerX;
            int nextPlayerY = player.playerY;

                if (_key.Key == ConsoleKey.UpArrow || _key.Key == ConsoleKey.Z)
                {
                    nextPlayerY--;
                }
                else if (_key.Key == ConsoleKey.DownArrow || _key.Key == ConsoleKey.S)
                {
                    nextPlayerY++;
                }
                else if (_key.Key == ConsoleKey.LeftArrow || _key.Key == ConsoleKey.Q)
                {
                    nextPlayerX--;
                }
                else if (_key.Key == ConsoleKey.RightArrow || _key.Key == ConsoleKey.D)
                {
                    nextPlayerX++;
                }
                else if (_key.Key == ConsoleKey.P)
                {
                    player.inventory.DisplayInventory();
                }

                if (map[nextPlayerY, nextPlayerX]!=1) 
                {
                    player.playerX = nextPlayerX; player.playerY = nextPlayerY;
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

