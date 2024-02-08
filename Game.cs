using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark
{
    internal class Game
    {
        Inventaire inventory = new Inventaire();
        Player player = new Player();
        public void newGame()
        {
            Console.Write("Voici les personnages jouables :\n\n");

            string playerAffichage = "Statistiques/Player_Affichage.csv";

            FileManager fileManager = new FileManager();
            fileManager.LecteurFichier(playerAffichage);

            Player.Stockeur();
            // Afficher la carte du donjon avec contours
            // FileManager.LecteurFichier();

            Console.Write("Bonjour tout le monde \n");
            Console.Write("Vous commencez l'aventure Savun low cost! \n");
            Console.Write("Pour vous déplacer vous pouvez utiliser ZQSD ou les flêches directionnelles.\n");
            Console.Write("Tapez n'importe quelle touche pour vous commencer.\n");

            inventory.AddItem("Clef", 5);
            inventory.AddItem("Bombe", 5);

            inventory.SaveInventory("inventory");

            Quest.quests = new List<Quest>();
            Quest.SaveQuests("quests");
            launchGame();
        }

        public void loadGame()
        {
            Player.Stockeur();
            inventory.LoadInventory("inventory");
            Quest.quests = new List<Quest>();
            Quest.LoadQuests("quests");

            launchGame();
        }

        public void launchGame()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            PNJ pnj1 = new PNJ("Gregouin", 3, 3);
            Map map = new Map();
            int[,] mapData = map.GenererMap1();

            Input input = new Input();

            

            player.inventory = inventory;

            while (key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey();
                Console.Clear();
                input.inputPlayer(key, player, mapData);
                map.AfficherMap1(player.playerX, player.playerY);
                if (player.playerX == pnj1.pnjX && player.playerY == pnj1.pnjY)
                {
                    pnj1.Talk(inventory);
                }
            }
        }
    }
}
