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

            string[] options = { "Nouvelle Partie", "Charger Partie", "Quitter" };

            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - options[i].Length / 2, Console.CursorTop);

                if (choix == i)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(">> ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("   ");
                }

                Console.WriteLine(options[i]);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");

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
