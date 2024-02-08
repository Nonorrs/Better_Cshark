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
            Console.Clear();
            Console.Write("Voici les personnages jouables :\n\n");

            string playerAffichage = "Statistiques/Player_Affichage.csv";

            FileManager fileManager = new FileManager();
            fileManager.LecteurFichier(playerAffichage);

            Player.Stockeur();
            
            // Afficher la carte du donjon avec contours
            // FileManager.LecteurFichier();

            Console.ReadLine();
            Console.Clear();
            Console.Write("Bonjour tout le monde \n");
            Console.Write("Vous commencez l'aventure Savun low cost! \n");
            Console.Write("Pour vous déplacer vous pouvez utiliser ZQSD ou les flêches directionnelles.\n");
            Console.Write("Tapez n'importe quelle touche pour vous commencer.\n");

            inventory.AddItem("Clef", 5);
            inventory.AddItem("Bombe", 5);

            Quest.quests = new List<Quest>();
            launchGame();
            //Battle.BattleBegin();
        }

        public void loadGame()
        {
            Console.Clear();
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
            Item oreiller = new Item("Oreiller", 1);
            Item potion = new Item("Potion", 2);
            Chest chest1 = new Chest(2, 12, oreiller);
            Chest chest2 = new Chest(24,12, potion);
            Chest[] chests= { chest1, chest2 };
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

                for (int i = 0; i < chests.Length; i++)
                {
                    if (player.playerX == chests[i].ChestX && player.playerY == chests[i].ChestY)
                    {
                        chests[i].FindChest(inventory);
                    }
                }
            }
        }
    }
}
