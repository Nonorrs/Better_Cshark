using Better_Cshark;
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Voici les personnages jouables :\n\n"); 

        string playerAffichage = "Statistiques/Player_Affichage.csv";
        FileManager.LecteurFichier(playerAffichage);

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
        

        int[,] map1 = Map.GenererMap1();
        Input.MovePlayer(map1);

        Console.ReadKey();
    }
}
