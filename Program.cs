using Better_Cshark;
using System;
class Program
{
    static void Main(string[] args)
    {

        string playerAffichage = "Statistiques/Player_Affichage.csv";
        FileManager.LecteurFichier(playerAffichage);
        // Afficher la carte du donjon avec contours
        //FileManager.LecteurFichier();

        Console.Write("Bonjour tout le monde \n");
        Console.Write("Vous commencez l aventure Savun low cost! \n");

        Inventaire inventory = new Inventaire();

        inventory.LoadInventory("inventory");
        inventory.DisplayInventory();
        

        int[,] map1 = Map.GenererMap1();
        Input.MovePlayer(map1);

        Player.Stockeur();

        Console.ReadKey();
    }
}
