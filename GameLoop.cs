using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better_Cshark
{
    public class GameLoop
    {
        public void Loop()
        {
            Console.Write("Voici les personnages jouables :\n\n");

            string playerAffichage = "Statistiques/Player_Affichage.csv";

            FileManager fileManager = new FileManager();
            fileManager.LecteurFichier(playerAffichage);

            Player.Stockeur();
            // Afficher la carte du donjon avec contours
            //FileManager.LecteurFichier();

            Console.Write("Bonjour tout le monde \n");
            Console.Write("Vous commencez l'aventure Savun low cost! \n");
            Console.Write("Pour vous déplacer vous pouvez utiliser ZQSD ou les flêches directionnelles.\n");
            Console.Write("Tapez n'importe quelle touche pour vous commencer.\n");

            Inventaire inventory = new Inventaire();
            inventory.LoadInventory("inventory");
            inventory.DisplayInventory();

            Map map = new Map();
            int[,] map1 = map.GenererMap1();

            Input input = new Input();
            input.MovePlayer(map1);

            Console.ReadKey();
        }
    }
}
