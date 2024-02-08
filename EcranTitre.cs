using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark
{
    internal class EcranTitre
    {
        Game game = new Game();
        public int choix=0;
        public void AfficherEcranTitre()
        {
            Console.Clear();
            if (choix==0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nouvelle Partie");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Charger Partie");
                Console.WriteLine("Quitter");

            }
            else if (choix==1)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Nouvelle Partie");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Charger Partie");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Quitter");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Nouvelle Partie");
                Console.WriteLine("Charger Partie");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Quitter");
                Console.ForegroundColor = ConsoleColor.Gray;

            }
            choisirOption();
        }

        public void choisirOption()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {
                if (choix == 0)
                {
                    game.newGame();
                }
                else if (choix == 1)
                {
                    game.loadGame();
                }
                else if (choix == 2)
                {
                    Environment.Exit(0);
                }
            }

            if (key.Key == ConsoleKey.UpArrow)
            {
                choix--;
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                choix++;
            }
            if (choix == -1)
            {
                choix = 2;
            }
            if (choix == 3)
            {
                choix = 0;
            }
            AfficherEcranTitre();
        }
    }
}
